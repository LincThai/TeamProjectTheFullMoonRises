using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // set variables
    // timer variables
    [Header("Timer")]
    [SerializeField] TMP_Text timerText;
    float remainingTime;
    [SerializeField] float maxTime;

    // punishment variables
    [Header("Time Punishment")]
    [SerializeField] float timeReduction = 1;
    [SerializeField] bool isPunished = false;
    [SerializeField] int numOfTtimes = 0;

    // scene change variables
    [Header("Scene Change")]
    [SerializeField] bool isFirstLv = false;
    [SerializeField] int sceneIndex;

    // reference to other scripts
    [Header("References")]
    public AnswerCheck answerCheck;
    public GameObject resultsMenu;

    private void Awake()
    {
        // set the remaining time to the max time limit
        remainingTime = maxTime;

        // get the current scene index amd add 1 for the next scene
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Start()
    {
        // collect data from game manager
        isPunished = GameManager.Instance.willPunish;
        numOfTtimes = GameManager.Instance.numOfIncorrect;

        // call function to check for punishment time reduction
        PTimeReduction();
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0 )
        {
            // reduce time
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            // sets time to 0 so it doesn't go into the negatives
            remainingTime = 0;

            // call event here after time runs out
            timerText.color = Color.red;
            answerCheck.CheckAnswers();

            // check if it is the first level
            if (isFirstLv)
            {
                // loads the next level
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                // activate the results menu
                resultsMenu.SetActive(true);
                // unlock cursor
                Cursor.lockState = CursorLockMode.None;
            }
        }

        // set variables for minutes and seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        // display as text in a format
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PTimeReduction()
    {
        // checks if there is a punishment
        if (isPunished)
        {
            // reduce remaining time by time reduction multiplied by the number of times
            remainingTime -= timeReduction * numOfTtimes;
            Debug.Log(remainingTime);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // set variables
    // timer variables
    [Header("Timer")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] float maxTime = 3;

    // punishment variables
    [Header("Time Punishment")]
    [SerializeField] float timeReduction = 1;
    [SerializeField] bool isPunished = false;
    [SerializeField] int numOfTtimes = 0;



    private void Awake()
    {
        // set the remaining time to the max time limit
        remainingTime = maxTime;

        // call function to check for punishment time reduction
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0 )
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;

            // call event here after time runs out
            timerText.color = Color.red;
        }

        // reduce time
        remainingTime -= Time.deltaTime;
        // set variables for minutes and seconds
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        // display as text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PTimeReduction()
    {
        // checks if there is a punishment
        if (isPunished)
        {
            // reduce remaining time by time reduction multiplied by the number of times
            remainingTime -= timeReduction * numOfTtimes;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsUI : MonoBehaviour
{
    // set variables
    // UI
    [Header("UI References")]
    public TMP_Text correctText;
    public TMP_Text incorrectText;

    // Data
    [Header("Data Reference")]
    public AnswerCheck answerCheck;

    [Header("Data")]
    // data to display
    public int correctAnswers;
    public int incorrectAnswers;

    // scene data
    private int sceneIndex;

    private void Awake()
    {
        // get the current scene index amd add 1 for the next scene
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update()
    {
        // assign values to the variables to display
        correctAnswers = answerCheck.numOfCorrect;
        incorrectAnswers = answerCheck.numOfIncorrect;

        // write text to text ui elements
        correctText.text = correctAnswers.ToString();
        incorrectText.text = incorrectAnswers.ToString();
    }

    public void LoadNextScene()
    {
        // call function to calculate total aggregate scores
        GameManager.Instance.AggregateScores();
        // load next scene
        SceneManager.LoadScene(sceneIndex);
    }
}
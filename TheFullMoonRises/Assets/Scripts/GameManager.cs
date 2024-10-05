using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // set Variables
    public static GameManager Instance;

    // values to store
    [Header("Data To Store")]
    [SerializeField] public int numOfIncorrect;
    [SerializeField] public int numOfCorrect;
    [SerializeField] public bool willPunish;

    // values for ending
    [SerializeField] public int maxCorrect;
    [SerializeField] public int totalCorrect;
    [SerializeField] public int maxIncorrect;
    [SerializeField] public int totalIncorrect;

    private void Awake()
    {
        // check if there is already an instance of this game object
        if (Instance != null)
        {
            // Destroy that instance of this game object
            Destroy(gameObject);
            return;
        }

        // assign this instance to this game object
        Instance = this;
        // when loading don't destroy this object
        DontDestroyOnLoad(gameObject);
    }

    public void AggregateScores()
    {
        // Adds values to the totals
        totalCorrect += numOfCorrect;
        totalIncorrect += numOfIncorrect;

        Debug.Log("Total T: " + totalCorrect + "Total F: " + totalIncorrect);
    }

    public void CheckScore()
    {
        if (totalCorrect > maxCorrect)
        {
            Debug.LogWarning("The total number of correct answers is greater than the max");
            return;
        }

        if (totalIncorrect > maxIncorrect) { }

    }
}

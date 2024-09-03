using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // set Variables
    public static GameManager Instance;

    // reference to answer check
    public AnswerCheck answerCheck;

    // values to store
    [SerializeField] public int numOfIncorrect;
    [SerializeField] public int numOfCorrect;
    [SerializeField] public bool willPunish;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // set Variables
    public static GameManager Instance;

    // reference to answer check
    public AnswerCheck answerCheck;

    // values to store
    [SerializeField] private int numOfIncorrect;
    [SerializeField] private int numOfCorrect;
    [SerializeField] private bool willPunish;

    private void Awake()
    {
        // assign this instance to this game object
        Instance = this;
        // when loading don't destroy this object
        DontDestroyOnLoad(gameObject);
    }
}

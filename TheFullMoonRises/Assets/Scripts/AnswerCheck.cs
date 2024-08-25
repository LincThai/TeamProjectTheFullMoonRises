using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    //set variables
    // lists/arrays for selected objects and answers
    public List<GameObject> selectedObjects;
    public List<string> answers;
    // int variable counting the number of incorrect
    public int numOfIncorrect;

    public void CheckAnswers()
    {
        if (answers.Count != selectedObjects.Count)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i] != )
                {
                    
                }
            }
        }
    }

    public void AddItem(GameObject gameObject)
    {
        selectedObjects.Add(gameObject);
    }
}
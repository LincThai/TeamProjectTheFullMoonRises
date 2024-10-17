using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Globalization;

public class AnswerCheck : MonoBehaviour
{
    // set variables
    // lists/arrays for selected objects and answers
    [Header("Lists")]
    public List<GameObject> selectedObjects = new List<GameObject>();
    public List<string> answers = new List<string>();

    // int variable counting the number of correct/incorrect
    [Header("Important Values")]
    public int numOfIncorrect;
    public int numOfCorrect;

    public void CheckAnswers()
    {
        Debug.Log("Is called");
        // if selected objects list has objects in it
        if (selectedObjects.Count > 0)
        {
            // set values to zero
            numOfCorrect = 0;
            numOfIncorrect = 0;

            // guard statement
            if (answers.Count <= 0) { Debug.LogWarning("You have No Answers"); return; }

            for (int i = 0; i < answers.Count; i++)
            {
                Debug.Log("Looped");
                // using the count function in system.linq compare the items in the lists, count items with the same name
                numOfCorrect += selectedObjects.Count(x => x.GetComponent<Selectable>().objectName == answers[i]);
            }
            if (selectedObjects.Count >= answers.Count)
            {
                numOfIncorrect = selectedObjects.Count - answers.Count;
            }
            else
            {
                numOfIncorrect = selectedObjects.Count - numOfCorrect;
            }
            numOfIncorrect += answers.Count - numOfCorrect;

            Debug.Log("Correct: " + numOfCorrect + " Incorrect: " + numOfIncorrect);
            // Send values to game Manager
            GameManager.Instance.numOfCorrect = numOfCorrect;
            GameManager.Instance.numOfIncorrect = numOfIncorrect;

            if (numOfIncorrect > 0)
            {
                // set bool to true
                GameManager.Instance.willPunish = true;
            }
            else
            {
                // set bool to true
                GameManager.Instance.willPunish = false;
            }
        }
    }

    public void AddItem(GameObject gameObject)
    {
        // check if they have the Selectable script
        if (gameObject.GetComponent<Selectable>() != null)
        {
            // add game objects to selected objects list
            selectedObjects.Add(gameObject);
        }
    }

    public void RemoveItem(GameObject gameObject)
    {
        // check if they have the Selectable script
        if (gameObject.GetComponent<Selectable>() != null)
        {
            // removes from selected objects list
            selectedObjects.Remove(gameObject);
        }
    }
}
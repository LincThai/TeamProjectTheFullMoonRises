using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        // if selected objects list has objects in it
        if (selectedObjects.Count > 0)
        {
            // set values to zero
            numOfCorrect = 0;
            numOfIncorrect = 0;

            for (int i = 0; i < answers.Count; i++)
            {
                // using the count function in system.linq compare the items in the lists and count when they are the same or different
                // and add them to the variables
                numOfCorrect += selectedObjects.Count(x => x.GetComponent<Selectable>().objectName == answers[i]);
                numOfIncorrect += selectedObjects.Count(x => x.GetComponent<Selectable>().objectName != answers[i]);
            }

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
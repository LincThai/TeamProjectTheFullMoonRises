using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    //set variables
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
        // variable for the selected object list index
        int index = 0;

        // check if they don't have same count
        if (answers.Count != selectedObjects.Count)
        {
            // for every item in answers list
            for (int i = 0; i < answers.Count; i++)
            {
                // check if the object name in the selectable code is not the same
                if (answers[i] != selectedObjects[index].GetComponent<Selectable>().objectName)
                {
                    index++;
                }
                else 
                {
                    // increase the number of correct answers
                    numOfCorrect++;
                    // send value to game manager
                    GameManager.Instance.numOfCorrect = numOfCorrect;
                }
            }
            // calculate the number of incorrect answers
            numOfIncorrect = selectedObjects.Count - answers.Count;
            // send value to game manager
            GameManager.Instance.numOfIncorrect = numOfIncorrect;
            // set bool to false
            GameManager.Instance.willPunish = true;
            return;
        }
        else { GameManager.Instance.willPunish = false; return; }
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
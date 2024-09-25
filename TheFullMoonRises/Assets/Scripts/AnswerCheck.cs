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
        if (selectedObjects.Count > 0)
        {
            numOfCorrect = 0;
            numOfIncorrect = 0;

            for (int i = 0; i < answers.Count; i++)
            {
                numOfCorrect += selectedObjects.Count(x => x.GetComponent<Selectable>().objectName == answers[i]);
                numOfIncorrect += selectedObjects.Count(x => x.GetComponent<Selectable>().objectName != answers[i]);

                //// check if the object name in the selectable code is not the same
                //if (answers[i] != selectedObjects[index].GetComponent<Selectable>().objectName)
                //{
                //    // increase index
                //    index++;
                //    //Debug.Log(index);
                //    // check if index is higher than the count of selectedObjects list 
                //    if (index >= selectedObjects.Count)
                //    {
                //        // set index equal to the selectedObjects count - 1 as lists start from 0
                //        // meaning the size of a list = n-1
                //        index = selectedObjects.Count - 1;
                //        //Debug.Log(index);
                //    }
                //}
                //else
                //{
                //    // increase the number of correct answers
                //    numOfCorrect++;
                //    // check if the number
                //    if (numOfCorrect >= answers.Count)
                //    {
                //        // set value to max
                //        numOfCorrect = answers.Count;
                //    }
                //    Debug.Log("Correct " + numOfCorrect);
                //    // send value to game manager
                //    GameManager.Instance.numOfCorrect = numOfCorrect;
                //}
            }

            GameManager.Instance.numOfCorrect = numOfCorrect;
            GameManager.Instance.numOfIncorrect = numOfIncorrect;
        }

        if (answers.Count <= selectedObjects.Count)
        {
            // calculate the number of incorrect answers
            numOfIncorrect = selectedObjects.Count - answers.Count;
            Debug.Log( "Incorrect " + numOfIncorrect);
        }
        else
        { 
            numOfIncorrect = 0; 
            Debug.Log("Incorrect " + numOfIncorrect); 
        }

        // send value to game manager
        GameManager.Instance.numOfIncorrect = numOfIncorrect;

        // set bool to true
        GameManager.Instance.willPunish = true;
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
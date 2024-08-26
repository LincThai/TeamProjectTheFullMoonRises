using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    // set variables
    [SerializeField] private bool hasInteracted;
    [SerializeField] private float interactiveDistance = 10;
    [SerializeField] public string objectName;

    // reference to answercheck script
    [SerializeField] public GameObject bedObject;
    public AnswerCheck answerCheck;

    private void Awake()
    {
        // assign the game object
        bedObject = GameObject.FindWithTag("Main");
        answerCheck = bedObject.GetComponent<AnswerCheck>();
    }

    private void OnMouseDown()
    {
        Debug.Log("has clicked");
        // if the distance from the player to this object is less the interactive distance
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            // check if you've interacted with this object
            if (!hasInteracted)
            {
                Debug.Log("Add");
                // adds item to selected list
                answerCheck.AddItem(this.gameObject);
                // set to true
                hasInteracted = true;
            }
            else
            {
                Debug.Log("Remove");
                // remove item from selected list
                answerCheck.RemoveItem(this.gameObject);
                // set to false
                hasInteracted = false;
            }
        }
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            //
        }
    }
}

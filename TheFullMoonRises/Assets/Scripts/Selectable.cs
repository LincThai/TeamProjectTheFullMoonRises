using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    // set variables
    [SerializeField] private bool isInteractable;
    [SerializeField] private float interactiveDistance = 2;
    [SerializeField] public string objectName;

    // reference to answercheck script



    private void OnMouseDown()
    {
        // moves to next level if the this object is interactable and
        // the distance from the player to this object is less the interactive distance
        if (isInteractable == true &&
            Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            
        }
    }

    private void OnMouseOver()
    {
        if (isInteractable == false && 
            Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {

        }
    }
}

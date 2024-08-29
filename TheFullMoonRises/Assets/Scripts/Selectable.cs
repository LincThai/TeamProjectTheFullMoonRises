using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    // set variables
    [Header("Interactivity")]
    [SerializeField] private bool hasInteracted;
    [SerializeField] private float interactiveDistance = 10;
    [SerializeField] public string objectName;

    // reference to answercheck script
    [Header("Reference")]
    [SerializeField] public GameObject bedObject;
    public AnswerCheck answerCheck;

    // variables for outline
    [Header("Outline")]
    [SerializeField] public Color outlineColourSel = Color.green;
    [SerializeField] public Color outlineColourHov = Color.blue;
    [SerializeField] public Color outlineColourDe = Color.red;
    [SerializeField] public float outlineWidth = 5;

    private void Awake()
    {
        // assign the game object
        bedObject = GameObject.FindWithTag("Main");
        answerCheck = bedObject.GetComponent<AnswerCheck>();
    }

    private void OnMouseDown()
    {
        Debug.Log("has clicked");
        // if the distance from the player (main camera) to this object is less than the interactive distance
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
                // call outline function and pass the selection colour
                OutlineObject(outlineColourSel);
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
        // if the distance from the player (main camera) to this objects is less than the interactive distance
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            // check if this object has been interacted with
            if (!hasInteracted) 
            {
                // call outline function and pass the hover colour
                OutlineObject(outlineColourHov);
            }
            else 
            {
                // // call outline function and pass the deselection colour
                OutlineObject(outlineColourDe);
            }
        }
    }

    public void OutlineObject(Color color)
    {
        // check if there is an Outline component
        if (this.gameObject.GetComponent<Outline>() != null)
        {
            // enable the outline component
            this.gameObject.GetComponent<Outline>().enabled = true;
        }
        else
        {
            // add the outline component to this game object
            Outline outline = this.gameObject.AddComponent<Outline>();
            // enable it
            outline.enabled = true;
            // assign outline colour
            outline.OutlineColor = color;
            // assign outline width
            outline.OutlineWidth = outlineWidth;
        }
    }
}
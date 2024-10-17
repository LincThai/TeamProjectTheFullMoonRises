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
    private GameObject bedObject;
    private AnswerCheck answerCheck;

    // variables for outline
    [Header("Outline")]
    [SerializeField] public Color outlineColourSel = Color.green;
    [SerializeField] public Color outlineColourHov = Color.white;
    [SerializeField] public float outlineWidth = 5;
    [SerializeField] bool isFirstLv = false;

    private string[] sounds = new string[] { "InteractA", "InteractB", "InteractC" };
    private int index;

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
        // it will also check if this is not the first level
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance && !isFirstLv)
        {
            // check if you've interacted with this object
            if (!hasInteracted)
            {
                Debug.Log("Add");
                // adds item to selected list
                answerCheck.AddItem(this.gameObject);
                // set to true
                hasInteracted = true;
                // play random interaction sound effect
                index = Random.Range(0, 3);
                Debug.Log(sounds[index]);
                AudioManager.Instance.Play(sounds[index]);
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
                // play random interaction sound effect
                index = Random.Range(0, 3);
                Debug.Log(sounds[index]);
                AudioManager.Instance.Play(sounds[index]);
            }
        }
    }

    private void OnMouseOver()
    {
        // if the distance from the player (main camera) to this objects is less than the interactive distance
        // it will also check if this is the not first level
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance && !isFirstLv)
        {
            // check if this object has been interacted with
            if (!hasInteracted) 
            {
                // call outline function and pass the hover colour
                OutlineObject(outlineColourHov);
            }
        }
    }

    private void OnMouseExit()
    {
        // check if it hasn't been interacted with
        if (!hasInteracted)
        {
            // check if this object exists
            if(this.gameObject.GetComponent<Outline>() != null)
            {
                // disable this component
                this.gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }

    public void OutlineObject(Color color)
    {
        // check if there is an Outline component
        if (this.gameObject.GetComponent<Outline>() != null)
        {
            // assign it to a variable
            Outline outline = this.gameObject.GetComponent<Outline>();
            // enable the outline component
            outline.enabled = true;
            // assign outline colour
            outline.OutlineColor = color;
            // assign outline width
            outline.OutlineWidth = outlineWidth;
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
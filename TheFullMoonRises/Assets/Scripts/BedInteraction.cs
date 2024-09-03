using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedInteraction : MonoBehaviour
{
    // set Variables
    // interaction variables
    [Header("Interaction")]
    [SerializeField] public int sceneIndex;
    [SerializeField] private bool isInteractable = true;
    [SerializeField] private float interactiveDistance = 10;
    // outline vvariables
    [Header("Outline")]
    [SerializeField] public Color outlineColour = Color.blue;
    [SerializeField] public float outlineWidth = 5;

    private AnswerCheck answerCheck;

    public void Awake()
    {
        // starts as false
        isInteractable = false;
        // get the current scene index amd add 1 for the next scene
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        answerCheck = GetComponent<AnswerCheck>();
    }

    private void Update()
    {
        if (answerCheck.selectedObjects.Count > 0)
        {
            isInteractable = true;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("On Mouse Down");
        // moves to next level if the bed is interactable and
        // the distance from the player to bed is less the interactive distance
        if (isInteractable == true && Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            Debug.Log("is called");
            // call check answers function
            answerCheck.CheckAnswers();

            // loads the next level
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private void OnMouseOver()
    {
        // check if it is interactable and the distance
        // between this object and the main camera is less than interactive distance
        if (isInteractable == true && Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            OutlineBed(outlineColour);
        }
    }

    private void OnMouseExit()
    {
        // check if there is an outline script component
        if (this.gameObject.GetComponent<Outline>() != null)
        {
            // disable this component
            this.gameObject.GetComponent<Outline>().enabled = false;
        }   
    }

    public void OutlineBed(Color color)
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

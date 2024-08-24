using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedInteraction : MonoBehaviour
{
    // set Variables
    [SerializeField] public int sceneIndex;
    [SerializeField] private bool isInteractable;
    [SerializeField] private float interactiveDistance = 2;

    public void Awake()
    {
        // starts as false
        isInteractable = false;
        // get the current scene index amd add 1 for the next scene
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnMouseDown()
    {
        // moves to next level if the bed is interactable and
        // the distance from the player to bed is less the interactive distance
        if (isInteractable == true && 
            Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            // loads the next level
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

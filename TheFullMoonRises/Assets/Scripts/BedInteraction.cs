using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedInteraction : MonoBehaviour
{
    // set Variables
    [SerializeField] public string nextLevel;
    [SerializeField] private bool isInteractable;
    [SerializeField] private float interactiveDistance = 2;

    private void Start()
    {
        // starts as false
        isInteractable = false;
    }

    private void OnMouseDown()
    {
        // moves to next level if the bed is interactable and
        // the distance from the player to bed is less the interactive distance
        if (isInteractable == true && 
            Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}

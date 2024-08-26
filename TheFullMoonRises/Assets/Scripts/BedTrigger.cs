using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedTrigger : MonoBehaviour
{
    // variables
    public int sceneIndex;

    public void Awake()
    {
        // get the current scene index amd add 1 for the next scene
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("In Trigge");
        // left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" is called");
            // move to next scene
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
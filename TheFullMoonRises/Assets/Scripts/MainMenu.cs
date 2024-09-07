using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //// Define a public method called PlayGame
    public void PlayGame()
    {
        // Get the index of the current active scene and load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quit the game
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}


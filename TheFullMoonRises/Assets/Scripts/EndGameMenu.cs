using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public void ReturnToTitle()
    {
        // loads the title scene that should always have the index of 0
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // Quits the game
        Debug.Log("Quit the game");
        Application.Quit();
    }
}

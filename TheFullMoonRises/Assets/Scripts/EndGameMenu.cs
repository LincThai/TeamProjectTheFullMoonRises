using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    // set variables
    public Image goodEnd;
    public Image badEnd;

    private void Start()
    {
        ChangeEnding();
    }

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

    private void ChangeEnding()
    {
        if (GameManager.Instance.hasLost == true)
        {
            goodEnd.enabled = false;
            badEnd.enabled = true;
        }

        if (GameManager.Instance.hasLost == false)
        {
            goodEnd.enabled = true;
            badEnd.enabled = false;
        }
    }
}

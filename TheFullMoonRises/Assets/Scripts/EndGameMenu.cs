using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    // set variables
    public TMP_Text endGameText;

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
            endGameText.text = "You Win";
        }

        if (GameManager.Instance.hasLost == false)
        {
            endGameText.text = "You Lose";
        }
    }
}

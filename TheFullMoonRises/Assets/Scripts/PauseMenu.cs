using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject billingMenuUI;

    private float gameTime = 0f;
    public float targetTime = 10f;

    void Update()
    {
        if (!GameIsPaused)
        {
            gameTime += Time.deltaTime;
            // Check whether the target time is reached
            if (gameTime >= targetTime)
            {
                ShowBillingMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) 
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    // Resume pausing and hiding UI
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Method of pausing the game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //Stop time
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("quitting game..");
        Application.Quit();
    }
   
    void ShowBillingMenu()
    {
        // 显示结算菜单UI
        billingMenuUI.SetActive(true);
        // 停止游戏时间
        Time.timeScale = 0f;
        // 设置游戏状态为暂停
        GameIsPaused = true;
    }
}

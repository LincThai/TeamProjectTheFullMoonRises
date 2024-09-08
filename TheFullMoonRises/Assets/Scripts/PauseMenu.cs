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
            // ����Ƿ�ﵽĿ��ʱ��
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
    }

    // Method of pausing the game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //Stop time
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("UI test_level2");
    }

    public void QuitGame()
    {
        Debug.Log("quitting game..");
        Application.Quit();
    }
   
    void ShowBillingMenu()
    {
        // ��ʾ����˵�UI
        billingMenuUI.SetActive(true);
        // ֹͣ��Ϸʱ��
        Time.timeScale = 0f;
        // ������Ϸ״̬Ϊ��ͣ
        GameIsPaused = true;
    }
}

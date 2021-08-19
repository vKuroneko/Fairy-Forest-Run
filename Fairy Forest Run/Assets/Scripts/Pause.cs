using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameisOver = false;
    public GameObject PauseMenuUI;
    public GameObject GameOverUI;

    void Awake()
    {
        GameIsPaused = false;
        GameisOver = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(!GameisOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(GameIsPaused)
                    ResumeGame();
                else
                    PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitGame()
    {
        Debug.Log("Application has Quit");
        Application.Quit();
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameisOver = true;
    }

}

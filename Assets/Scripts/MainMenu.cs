using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static bool GameIsPaused;

    public GameObject MainMenuUI;

    private void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (GameIsPaused)
            {
                Resume();
            }
    }

    public void Resume()
    {
        MainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    public void start()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
        Debug.Log("game...");
    }

    public void scoreboard()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ScoreBorad");
        Debug.Log("score...");
    }

    public void quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("exit");
    }



}

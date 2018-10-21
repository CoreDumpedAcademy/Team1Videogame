using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public bool Playerdead;
    public GameObject DeadMenuUI;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Playerdead)
        {
            DeadMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    public void scoreboard()
    {
        
        SceneManager.LoadScene("ScoreBoard");
        Debug.Log("score...");
        Time.timeScale = 1f;

    }

    public void restart()
    {
        
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
        Debug.Log("restart...");
        Time.timeScale = 1f;
    }

    public void exitMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu...");
        Time.timeScale = 1f;
    }



}

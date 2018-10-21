using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text Score;
    public float timer;
    public int score = 0;

    Dictionary<string, Dictionary<string, int>> playerScores;
	// Use this for initialization
	void Start () {
        SetScore("raular4322", "puntos", 10000);
        Debug.Log(GetScore("raular4322", "puntos"));
    }
    void init()
    {
        if (playerScores != null)
            return;
        playerScores = new Dictionary<string, Dictionary<string, int>>();
    }
    public int GetScore(string username, string scoreType)
    {
        init();
        if (playerScores.ContainsKey(username) == false)
        {
            return 0;
        }
        if (playerScores[username].ContainsKey(scoreType) == false)
        {
            return 0;
        }
        return playerScores[username][scoreType];
    }
    public void SetScore(string username, string scoreType, int value)
    {
        init();
        if (playerScores.ContainsKey(username) == false)
        {
            playerScores[username] = new Dictionary<string, int>();
        }
        playerScores[username][scoreType] = value;
    }
    public void ChangesScore(string username, string scoreType, int amount)
    {
        init();
        int currScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currScore + amount);
    }




    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
	}

    private void FixedUpdate()
    {
        if (timer > 5f)
        {
            score += 100;
            Score.text = "Score: " + score;
            Debug.Log(score);
            timer = 0;
        }
    }
}

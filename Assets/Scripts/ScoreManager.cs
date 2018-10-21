using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text Score;
    public float timer;
    public int score = 0;
	// Use this for initialization
	void Start () {
        
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

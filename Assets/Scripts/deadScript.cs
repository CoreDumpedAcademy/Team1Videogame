using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadScript : MonoBehaviour {

    private controls player;
    private DeadMenu GameObject;
    private ScoreManager score;
 
	// Use this for initialization
	void Start () {
        player = GetComponentInParent<controls>();
        GameObject = GetComponent<DeadMenu>();
        score = GetComponentInParent<ScoreManager>();
    }
    
    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Deadly")
        {
            player.dead = true;
            GameObject.Playerdead = true;
            score.SetScore(score.score, "raular4322");
        }
    }
}

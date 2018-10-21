using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadScript : MonoBehaviour {

    private controls player;
    private DeadMenu GameObject;
 
	// Use this for initialization
	void Start () {
        player = GetComponentInParent<controls>();
        GameObject = GetComponent<DeadMenu>();
    

    }
    
    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Deadly")
        {
            player.dead = true;
            GameObject.Playerdead = true;
            
        }
    }
}

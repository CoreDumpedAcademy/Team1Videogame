using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadScript : MonoBehaviour {

    private controls player;

	// Use this for initialization
	void Start () {
        player = GetComponentInParent<controls>();
	}
    
    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Deadly")
        {
            player.dead = true;
        }
    }
}

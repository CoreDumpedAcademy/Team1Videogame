﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkGround : MonoBehaviour {

    private controls player;

	// Use this for initialization
	void Start () {
    player = GetComponentInParent<controls>();
    }

     void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }
    }

     void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }   
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var number = Random.Range(1, 100);
        if (number < 95)
        {
            transform.localScale = new Vector3(0f, 0f, 0f);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

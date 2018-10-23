using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour {

	private Vector2 position;
	public Vector2 direction;
	public GameObject Platforms;
	public Vector2 speed;

    // Update is called once per frame
    void Update () {
		direction = new Vector2 (-1, 0);

		Vector2 movement = new Vector2 (direction.x * speed.x, 0);
		movement *= Time.deltaTime;
		transform.Translate (movement);
		position = new Vector2 ( 10f,Random.Range (-5f, 5f));
	}
}

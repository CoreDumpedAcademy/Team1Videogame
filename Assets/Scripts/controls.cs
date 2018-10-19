using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour {


	public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
	public float jumPower = 10f;

    
    private Rigidbody2D rb2d;
	private bool jump;


	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") && grounded)
        {
			jump = true;

        }
	}

	void FixedUpdate(){

		float h = Input.GetAxis("Horizontal");
		
		rb2d.AddForce(Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (h > 0.1f){
			transform.localScale = new Vector2(1f, 1f);
		}

		if (h < 0.1f){
			transform.localScale = new Vector2(-1f, 1f);
		}
			
		if (jump){

			rb2d.AddForce(Vector2.up * jumPower, ForceMode2D.Impulse);
			
			jump = false;
		}
	}
}

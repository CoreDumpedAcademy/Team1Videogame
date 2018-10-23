using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controls : MonoBehaviour {


	public float maxSpeed = 5f;
    public float speed = 5f;
    public bool grounded;
    public bool dead;
    public float jumPower = 10f;
    public ScoreManager player;
    private Rigidbody2D rb2d;
	private bool jump;
    public bool platform;
    private Vector2 position;
    private Vector2 direction;
    private GameObject Platforms;
    private Vector2 playerSpeed;


    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        player = GetComponentInParent<ScoreManager>();
        dead = false;
        playerSpeed = new Vector2(1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") && grounded)
        {
			jump = true;

        }
        if (platform)
        {
            direction = new Vector2(-1, 0);

            Vector2 movement = new Vector2(direction.x * playerSpeed.x, 0);
            movement *= Time.deltaTime;
            transform.Translate(movement);
            position = new Vector2(10f, Random.Range(-5f, 5f));
        }
        else
        {

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

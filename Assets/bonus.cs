using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour {

    public ScoreManager player;
    public int puntos;
	// Use this for initialization
	void Start () {
        player = GetComponentInParent<ScoreManager>();
        puntos = 500;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {
        BoxCollider2D bc;
        bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;

        bc.isTrigger = true;

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "1UP")
        {
            Destroy(col.gameObject);
            player.score += puntos;
            player.RefreshScore();
            //Debug.Log("puntos: " + puntos);
        }
    }
}

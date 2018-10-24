using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatform : MonoBehaviour {

    public GameObject[] obj;
    public float tiempoMin = 4f;
    public float tiempoMax = 6f;
    Random rand = new Random();

    float x;
    float y;
    float z;
    float y2;
    float y3;
    float y4;
    int b;

    Vector3 pos;
    Vector3 pos2;
    Vector3 pos3;
    Vector3 pos4;

    // Use this for initialization
    void Start () {
        GeneradorPlataformas();
	}
	
	// Update is called once per frame
	void Update () {

        x = 12.4f;
        y = Random.Range(-3f, -1.75f);
        z = 0;
        y2 = Random.Range(-1.75f, -0.5f);
        y3 = Random.Range(-0.5f, 0.75f);
        y4 = Random.Range(0.75f, 2f);


        pos = new Vector3(x, y, z);
        pos2 = new Vector3(x, y2, z);
        pos3 = new Vector3(x, y3, z);
        pos4 = new Vector3(x, y4, z);


        int platform = Random.Range(1, 5);
        
        if (platform == 1)
        {
            transform.position = pos;
            b = 3;
        }
        if (platform == 2)
        {
            transform.position = pos2;
            b = 3;
        }
        if (platform == 3)
        {
            transform.position = pos3;
            b = 4;
        }
        if (platform == 4)
        {
            transform.position = pos4;
            b = 4;
        }
    }

    void GeneradorPlataformas()
    {   
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("GeneradorPlataformas", Random.Range(tiempoMin, tiempoMax));
    }

}

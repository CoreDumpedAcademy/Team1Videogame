using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatform : MonoBehaviour {

    /*private float platform = 0;
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
        y = Random.Range(1.5f, 3f);
        z = 0;
        y2 = Random.Range(0f, 1.5f);
        y3 = Random.Range(-1.5f, 0f);
        y4 = Random.Range(-3f, -1.5f)


        pos = new Vector3(x, y, z);

        transform.position = pos;

    }

    void GeneradorPlataformas()
    {   if (platform == 0)
        {

        }
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("GeneradorPlataformas", Random.Range(tiempoMin, tiempoMax));
    }*/
}

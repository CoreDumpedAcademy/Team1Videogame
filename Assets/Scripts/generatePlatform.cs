using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatform : MonoBehaviour {

    public GameObject[] obj;
    Random rand = new Random();

    public int platform;
    public int altura2;
    public float tiempo;

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
        platform = 3;
        

    }
    public void FixedUpdate()
    {
        if (tiempo > 5f)
        {
            if (platform + 2 < 5)
            {
                altura2 = platform + 2;
                platform = Random.Range(0, altura2);
            }
            else
            {
                altura2 = 5;
                platform = Random.Range(0, altura2);
            }
            
            tiempo = 0;
        }
    }

    // Update is called once per frame
    void Update () {
        tiempo += Time.deltaTime;

        x = 12.4f;
        z = 0;
        y = Random.Range(-2.5f, -2f);
        y2 = Random.Range(-1f, -0.5f);
        y3 = Random.Range(0.5f, 1f);
        y4 = Random.Range(2f, 2.5f);


        pos = new Vector3(x, y, z);
        pos2 = new Vector3(x, y2, z);
        pos3 = new Vector3(x, y3, z);
        pos4 = new Vector3(x, y4, z);

        
        if (platform == 1)
        {
            transform.position = pos;
        }
        if (platform == 2)
        {
            transform.position = pos2;
        }
        if (platform == 3)
        {
            transform.position = pos3;
        }
        if (platform == 4)
        {
            transform.position = pos4;
        }
    }

    void GeneradorPlataformas()
    {   
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("GeneradorPlataformas", 5f);
    }

}

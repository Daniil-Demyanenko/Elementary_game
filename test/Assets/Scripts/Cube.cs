using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour {
    public Vector3 vec;
    public GameObject[] sphere;
    public Light Light;
    int Count;
    public int length;
    public Text CountText;
    public AudioClip Audio;

    void Start()
    {
        Count = 0;
        //GetComponent<AudioSource>().clip = Audio;
        StartCoroutine(spawn());
    }
    void OnMouseDown()
    {
        transform.localScale = new Vector3(0.5f,0.5f,0.5f);
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obj")
        {
            Destroy(other.gameObject);
            Count++;
            CountText.text = "Count: " + Count.ToString();
            StartCoroutine(light());
            StartCoroutine(spawn());
            GetComponent<AudioSource>().Play();
        }
    }


    void Update () {
        transform.Rotate(vec);

        float xPos = length * Input.GetAxis("Horizontal");
        float yPos = length * Input.GetAxis("Vertical");
        transform.position = new Vector3(xPos, yPos, 0);

        if (Input.GetKey(KeyCode.Alpha1)) {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            GetComponent<Renderer>().material.color = Color.black;
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

    }

    IEnumerator light () {
        Light.GetComponent<Light>().range = 3;
        yield return new WaitForSeconds(0.1f);
        Light.GetComponent<Light>().range = 1.9f;
    }
    IEnumerator spawn()
    {
        int r, randX, randY;
        yield return new WaitForSeconds(0.5f);

        if(UnityEngine.Random.Range(0, 2)==1)
            randX = UnityEngine.Random.Range(-10,-1);
        else randX = UnityEngine.Random.Range(1, 10);

        if (UnityEngine.Random.Range(0, 2) == 1)
            randY = UnityEngine.Random.Range(-10, -1);
        else randY = UnityEngine.Random.Range(1, 10);

        r = UnityEngine.Random.Range(0,3);
        Instantiate(sphere[r], sphere[r].transform.TransformPoint(randX, randY, 0f), sphere[r].transform.rotation);
    }

}

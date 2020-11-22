using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

public class Health : MonoBehaviour
{
    /*
    GameObject pivot_canvas;
    Transform canvas_trans;
    Transform health_size;
    public float decrement = 0.1f;
    float max_health = 0f;
    float max_distance = 0f;

    // Start is called before the first frame update
    void Start()
    {
        pivot_canvas = GameObject.Find("Canvas");
        canvas_trans = pivot_canvas.GetComponent<Transform>();
        health_size = GetComponent<Transform>();
        max_health = health_size.localScale.x;
        max_distance = canvas_trans.position.x - health_size.position.x;
    }

    public void shrink()
    {
        if (health_size.localScale.x != 0f)
        {
            float factor = max_health * decrement;
            float offset = max_distance * decrement;
            health_size.localScale = new Vector3(health_size.localScale.x - factor, health_size.localScale.y, health_size.localScale.z);
            health_size.position = new Vector3(health_size.position.x - offset / 2, health_size.position.y, health_size.position.z);
            UnityEngine.Debug.Log(health_size.localScale.x);
        }  
    }
    */
    GameObject green_1;
    GameObject green_2;
    GameObject green_3;
    GameObject green_4;

    int counter = 0;

    void Start()
    {
        green_1 = GameObject.Find("GreenBat1");
        green_2 = GameObject.Find("GreenBat2");
        green_3 = GameObject.Find("GreenBat3");
        green_4 = GameObject.Find("GreenBat4");
    }

    public void shrink()
    {
        if (counter == 0)
        {
            green_1.SetActive(false);
        }
        if (counter == 1)
        {
            green_2.SetActive(false);
        }
        if (counter == 2)
        {
            green_3.SetActive(false);
        }
        if (counter == 3)
        {
            green_4.SetActive(false);
        }
        counter++;
    }
}

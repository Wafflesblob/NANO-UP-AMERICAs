using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombMovement : MonoBehaviour
{
    Transform body;
    Rigidbody rb;
    public Vector3 spawner_vel;
    public float speed = 10f;

    int counter = 0;
    int max = 50;

    Renderer radiusColor;
    Color bombColor;

    Vector3 push;

    void Start()
    {
        body = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        push = body.forward * speed;
        push = new Vector3(push.x, push.y, push.z) + Vector3.Scale(spawner_vel, body.forward);
        rb.velocity = push;
    }

    void Update()
    {
        //rb.velocity = push;
        if (counter < max)
        {
            counter++;
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }



}

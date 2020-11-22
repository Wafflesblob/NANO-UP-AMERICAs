using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Transform body;
    Rigidbody rb;
    public Vector3 spawner_vel;
    public float speed = 20f;

    int counter = 0;
    int max = 50;

    Vector3 push;

    void Start()
    {
        body = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        push = body.forward * speed;
        push = new Vector3(push.x, push.y, push.z) + new Vector3(spawner_vel.x * body.forward.x, spawner_vel.y * body.forward.y, spawner_vel.z * body.forward.z);
    }

    void Update()
    {
        rb.velocity = push;

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

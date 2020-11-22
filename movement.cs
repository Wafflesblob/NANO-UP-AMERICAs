using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class movement : MonoBehaviour
{
    Transform body;
    Rigidbody rb;
    BulletMove bullet_script;
    public Transform barrel;
    public GameObject bullet;

    bombMovement bomb_script;
    public GameObject bomb;

    GameObject green;
    Health gs;

    public float speed = 2f;
    public float sensitivity = 120f;
    bool fire = true;
    int fireCounter = 0;
    int fireMax = 15;

    bool bombFire = true;
    int bombCounter = 0;
    int bombMax = 1000;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        body = GetComponent<Transform>();
        bullet_script = bullet.GetComponent<BulletMove>();
        green = GameObject.Find("Canvas");
        gs = green.GetComponent<Health>();

        bomb_script = bomb.GetComponent<bombMovement>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 walk = body.right * x * speed + body.forward * z * speed;

        rb.velocity = new Vector3(walk.x, rb.velocity.y, walk.z);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, speed, rb.velocity.z);
        }
        else if (Input.GetKey(KeyCode.LeftShift) != true)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector3(rb.velocity.x, -speed, rb.velocity.z);
        }
        else if (Input.GetKey(KeyCode.Space) != true)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }

        float x_axis = Input.GetAxis("Mouse X");
        float y_axis = Input.GetAxis("Mouse Y");

        float x_look = x_axis * sensitivity * Time.deltaTime;
        float y_look = y_axis * sensitivity * Time.deltaTime * -1; 

        body.Rotate(0f, x_look, 0f);

        if (fire)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(bullet, barrel.position + barrel.forward * 0.2f, barrel.rotation);
                bullet_script.spawner_vel = rb.velocity;
                fire = false;
            }
        }
        else
        {
            if (fireCounter < fireMax)
            {
                fireCounter++;
            }
            else
            {
                fireCounter = 0;
                fire = true;
            }
        }

        if (bombFire)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Instantiate(bomb, barrel.position + barrel.forward * 0.2f, barrel.rotation);
                bomb_script.spawner_vel = rb.velocity;
                bombFire = false;
            }
        }
        else
        {
            if (bombCounter < bombMax)
            {
                bombCounter++;
            }
            else
            {
                bombCounter = 0;
                bombFire = true;
            }
        }



        Quaternion ninety_degrees = Quaternion.Euler(-90f, 0f, 0f);  // Converts 90 degrees as a Euler Vector to a Quaternion
        Quaternion neg_ninety_degrees = Quaternion.Euler(45f, 0f, 0f);  // Converts -90 degrees as a Euler Vector to a Quaternion

        player_y_clamp(y_axis, ninety_degrees, neg_ninety_degrees, y_look);

    }
    void player_y_clamp(float y, Quaternion ninety, Quaternion neg_ninety, float sensitivity)
    {
        // We only compare the x-axis of the Camera's and 90/-90 degree quaternions as we are only focused on the rotation around the x-axis for the player's camera.
        if (y > 0 && Mathf.Round(barrel.rotation.x * 10) != Mathf.Round(ninety.x * 10))  // Checks if the Player is looking up and that the Angle of the Camera, rounded, is equal to that of the angle if it were at a full 90 degrees.
        {
            barrel.Rotate(sensitivity, 0f, 0f);  // Allows for rotation.
        }
        if (y < 0 && Mathf.Round(barrel.rotation.x * 10) != Mathf.Round(neg_ninety.x * 10))  // Checks if the Player is looking up and that the Angle of the Camera, rounded, is equal to that of the angle if it were at a full -90 degrees.
        {
            barrel.Rotate(sensitivity, 0f, 0f);  // Allows for rotation.
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            gs.shrink();
        }
    }
}

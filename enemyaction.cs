using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class enemyaction : MonoBehaviour
{
    float xchoice;
    float ychoice;
    float zchoice;
    public float min = -6f;
    public float max = 6f;
    int counter = 0;
    int spawnCounter = 0;
    public GameObject allKnowing;
    MotherScript ms;
    
    int timeMax = 1000;
    public int divisor = 40;
    public GameObject Enemy;
   


    public float enemy_health = 100f;
    public float laser_damage = 10f;

    public bool idle = true;
    public bool touchie = false;

    float xdistance;
    float ydistance;
    float zdistance;

    Rigidbody rb;
    GameObject player;
    Vector3 playerTransform;
    Transform enemy;

    public detect sc;
    public float vel = 0.1f;

    Renderer enemy_color;
    Color corona_color;
    float x_color_offset;
    float y_color_offset;
    float z_color_offset;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerTransform = player.transform.position;
        Enemy = GameObject.Find("Ene");
        allKnowing = GameObject.Find("Mother");
        ms = allKnowing.GetComponent<MotherScript>();
        // get player position
        sc = GetComponentInChildren<detect>();
        sc.ps = GetComponent<enemyaction>();

        enemy_color = GetComponent<Renderer>();
        corona_color = enemy_color.material.color;
        x_color_offset = (255f - (corona_color.r * 255f))  / 5;
        y_color_offset = (255f - (corona_color.g * 255f)) / 5;
        z_color_offset = (255f - (corona_color.b * 255f)) / 5;
    }

    // Update is called once per frame

    void Update()
    {
        playerTransform = player.transform.position;
        enemy = GetComponent<Transform>();

        //UnityEngine.Debug.Log(playerTransform);

        if (counter < divisor)
        {
            counter++;
        }
        else
        {
            xchoice = Random.Range(min, max);
            ychoice = Random.Range(min, max);
            zchoice = Random.Range(min, max);
            counter = 0;
        }
        if (idle)
        {
            rb.velocity = new Vector3(xchoice, ychoice, zchoice);
        }
        else
        {
            enemy.position = Vector3.MoveTowards(enemy.position, playerTransform, vel);
        }

        if (spawnCounter < timeMax)
        {
            spawnCounter++;
        }
        else
        {
            if (Random.Range(0,100) == 1 && ms.numAlive <= 20)
            {
                
                Instantiate(Enemy, enemy.position, enemy.rotation);
                ms.numAlive++;
                UnityEngine.Debug.Log(ms.numAlive);
                spawnCounter = 0;
            }
            

        }
    }

    float distance(Vector3 player, Vector3 enemy)
    {
        float xdistance = Mathf.Pow(2, (player.x - enemy.x));
        float ydistance = Mathf.Pow(2, (player.y - enemy.y));
        float zdistance = Mathf.Pow(2, (player.z - enemy.z));
        return Mathf.Sqrt(xdistance + ydistance + zdistance);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            enemy_health -= laser_damage;
            enemy_color.material.color = 
                new Color(enemy_color.material.color.r + x_color_offset/255f, enemy_color.material.color.g + y_color_offset / 255f, enemy_color.material.color.b + z_color_offset / 255f, enemy_color.material.color.a);
        }
        if (enemy_health == 0f)
        {
            
            Destroy(gameObject.transform.GetChild(0).gameObject);
            Destroy(gameObject);
            
        }
    }



}


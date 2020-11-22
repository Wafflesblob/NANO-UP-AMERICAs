using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientHealth : MonoBehaviour
{
    public int patientHealth = 5;

    float upperLimit;
    float midLimit;

    GameObject redCroissant;
    GameObject yellowCroissant;
    GameObject greenCroissant;
    GameObject blackCroissant;

    // Start is called before the first frame update
    void Start()
    {
        upperLimit = (patientHealth * 2) / 3;
        midLimit = patientHealth / 3;

        redCroissant = GameObject.Find("redCroissant");
        yellowCroissant = GameObject.Find("yellowCroissant");
        greenCroissant = GameObject.Find("greenCroissant");
        blackCroissant = GameObject.Find("blackCroissant");

    }

    // Update is called once per frame
    void Update()
    {
        if(patientHealth < upperLimit) {
            greenCroissant.SetActive(false);
        }
        if(patientHealth < midLimit)
        {
            yellowCroissant.SetActive(false);
        }
        if(patientHealth <= 0)
        {
            redCroissant.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (patientHealth > 0)
        {
            if (col.gameObject.tag == "Enemy")
            {
                patientHealth -= 1;
            }
        }
    }
}

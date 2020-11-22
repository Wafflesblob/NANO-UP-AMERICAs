using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour
{
    public GameObject parent;
    public enemyaction ps;

    void OnTriggerEnter(Collider defect)
    {

        if (defect.gameObject.tag == "Player")
        {
            ps.idle = false;
        }
        else
        {
            ps.idle = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform firePoint;
    public GameObject turretProjectile;
    public bool isInRange;
    public float initialTime;
    public Transform target;
    public float timer;

    
    // Start is called before the first frame update
    private void Start()
    {
        
        initialTime = 3;
        timer = initialTime;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (isInRange)
            {
                fire();
            }
        }
    }

    void fire()
    {
            
        Instantiate(turretProjectile, firePoint.position, firePoint.rotation);

        Debug.Log("fire");

        timer=initialTime;
    }
    
}
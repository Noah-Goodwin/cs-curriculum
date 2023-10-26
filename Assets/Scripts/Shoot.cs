using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private void Start()
    {

        initialTime = 3;
        timer = initialTime;
    }

    public float timer;
    public Transform firePoint;
    public GameObject playerProjectile;
    public float initialTime;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (Input.GetKeyDown("space"))
            {
                fire();
            }
        }

    }

    void fire()
    {

        Instantiate(playerProjectile, firePoint.position, firePoint.rotation);

        Debug.Log("fire");

        timer = initialTime;

    }
    
}
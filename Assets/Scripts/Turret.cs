using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject player;

    public GameObject turretProjectile;

    public float initialTime;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = initialTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) ;
        {
            timer -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0) ;
        {
            Vector3 target = player.transform.position;
            GameObject projectile = Instantiate(turretProjectile, transform.position, Quaternion.identity);
            projectile.transform.Translate(target);
            timer = initialTime;
        }
    }
}

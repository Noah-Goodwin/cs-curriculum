using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCode : MonoBehaviour
{
    private float iframesTimer;
    private float iframesTimerDefault = 1.5f;
    private bool iframes = false;
    private int health = 10;

    private Coin coinpurse;
    // Start is called before the first frame update
    void Start()
    {
        iframesTimer = iframesTimerDefault;
        coinpurse = FindObjectOfType<Coin>();
    }

    private void Update()
    {
        if (iframes)
        {
            iframesTimer -= Time.deltaTime;
            if (iframesTimer < 0)
            {
                iframes = false;
                //reset the timer
                iframesTimer = iframesTimerDefault;
            }
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
            }

            if (health < 1)
            {
                Death();
            }

        }
    }

    void Death()
    {
        coinpurse.Coins  = 0;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
    
    
    
    void ChangeHealth(int amount)
    {
        health += amount;
        Debug.Log("Health: "+health);

    }
}
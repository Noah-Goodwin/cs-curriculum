using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCode : MonoBehaviour
{

    private float ipotionTimer;
    private float iframesTimer;
    private float iframesTimerDefault = 1.5f;
    private bool iframes = false;
    public HUD hud;


    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        iframesTimer = iframesTimerDefault;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Potion"))
        {
            ChangeHealth(1);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Turret Bullet"))
        {
            if (!iframes)
            {
                ChangeHealth((-1));
                Destroy(other.gameObject);
                iframes = true;
            }
        }

        if (other.gameObject.CompareTag("IPotion"))
        {

            iframesTimer = 10f;
            iframes = true;
            Destroy(other.gameObject);

        }
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
            }




            if (hud.health < 1)
            {
                Death();
            }
        }
        
        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
            }



            if (hud.health < 1)
            {
                Death();
            }






        }
        }

        void Death()
        {
            hud.coins = 0;
            hud.health = 10;
            SceneManager.LoadScene("Start", LoadSceneMode.Single);
        }



        void ChangeHealth(int amount)
        {
            hud.health += amount;
            Debug.Log("Health: " + hud.health);

        }
    }

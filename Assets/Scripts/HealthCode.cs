using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCode : MonoBehaviour
{

    public GameObject invincible;
    public GameObject canvas;
    private float ipotionTimer;
    public float iframesTimer;
    private float iframesTimerDefault = 1.5f;
    public bool iframes = false;
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
                iframesTimer = iframesTimerDefault;
                BecomeInvincible();
            }
        }

        if (other.gameObject.CompareTag("IPotion"))
        {

            iframesTimer = 10f;
            iframes = true;
            BecomeInvincible();
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
                iframesTimer = iframesTimerDefault;
                BecomeInvincible();
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
                iframesTimer = iframesTimerDefault;
                BecomeInvincible();
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
        
        void BecomeInvincible()
        {
            GameObject newSmoke = Instantiate(invincible, new Vector3(1001, 532, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
            newSmoke.transform.SetParent(canvas.transform, false);
            newSmoke.transform.localScale = new Vector3(1, 1, 1);   
            Debug.Log("script finished");
        }
        
    }

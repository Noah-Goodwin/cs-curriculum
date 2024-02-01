using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCode : MonoBehaviour
{


    public GameObject canvas;
    private float ipotionTimer;
    public float iframesTimer;
    private float iframesTimerDefault = 1.5f;
    public bool iframes = false;
    public HUD hud;
    private float m_Red;
    private float m_Blue;
    float m_Green;
    private int changy;
    public GameObject player;
    SpriteRenderer m_SpriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        //iframesTimer = iframesTimerDefault;
        m_SpriteRenderer = player.GetComponent<SpriteRenderer>();

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

            }
        }

        if (other.gameObject.CompareTag("IPotion"))
        {

            iframesTimer = 10f;
            iframes = true;

            Destroy(other.gameObject);
            hud.ColorReset();

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
    
    void ChangeHealth(int amount)
    {
        hud.health += amount;
        Debug.Log("Health: " + hud.health);
        if (hud.health < 1)
        {
            Death();
        }
            
        if (amount < 0)
        {
            hud.ColorReset();
            StartCoroutine(ChangeColorCoroutine());


        }

    }
    IEnumerator ChangeColorCoroutine()
    {
        for (int i = 0; i < 4; i++)
        {
            m_SpriteRenderer.color = Color.black;
            yield return new WaitForSeconds(.1f); // Adjust the duration as needed

            hud.ColorReset();
            yield return new WaitForSeconds(.1f); // Adjust the duration as needed
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

            }





        }
        
        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
                iframesTimer = iframesTimerDefault;
  
            }





        }
        }
    


        void Death()
        {
            hud.coins = 0;
            hud.health = 10;
            SceneManager.LoadScene("Start", LoadSceneMode.Single);
            
            
            
        }




        

        
    }

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public int bossHealth;
    private float iframesTimer;
    private float iframesTimerDefault = 1;
    private bool iframes = false;
    private bool dead = false;
    private Animator m_Animator;

    private void Start()
    {
        iframesTimer = iframesTimerDefault;
    }



    
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!iframes)
            {
                ChangeOrcHealth(-1);
                iframes = true;
            }
            

        }

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if (!iframes)
            {
                ChangeOrcHealth(-1);
                iframes = true;
                
            }

            

            //collision.gameObject.SetActive(false);
            if (dead)
            {
                Destroy(collision.gameObject);
            }

        }
    }
    
    void Update()
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
        if (bossHealth <= 0)
        {
            StartCoroutine(Die(2));
        }
    }
    void Death()
    {
        
        //Destroy(gameObject);
    }
    void ChangeOrcHealth(int amount)
    {
        bossHealth += amount;
        Debug.Log("OrcHealth: " + bossHealth);
        if (bossHealth < 1)
        {
            //Death();
            //m_Animator.SetBool("Death", true);
        }
    }

    private IEnumerator Die(int time)
    {
        Debug.Log("Start Timer");
        yield return new WaitForSeconds(time);
        dead = true;
    }
}

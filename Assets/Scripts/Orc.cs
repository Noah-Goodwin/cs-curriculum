using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Object = UnityEngine.Object;

public class Orc : MonoBehaviour
{


    public bool isInRange;
    public Transform orctarget;
    public Transform iposition;
    private int OrcHealth;
    private float iframesTimer;
    private float iframesTimerDefault = 1;
    private bool iframes = false;
    private CircleCollider2D collider;


// Start is called before the first frame update
    private void Start()
    {
        iframesTimer = iframesTimerDefault;
        OrcHealth = 5;
        collider = gameObject.GetComponent<CircleCollider2D>();
        collider.radius = 3;
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

            if (OrcHealth < 1)
            {
                Destroy(gameObject);
            }

        }

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if (!iframes)
            {
                ChangeOrcHealth(-1);
                iframes = true;
                collider.radius = collider.radius + 3;
            }
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);

        }

    }

    void ChangeOrcHealth(int amount)
        {
            OrcHealth += amount;
            Debug.Log("OrcHealth: " + OrcHealth);
            if (OrcHealth < 1)
            {
                Destroy(gameObject);
            }
        }
        
        
        

    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collider.radius = collider.radius + 1.3f;
            isInRange = true;
        }
            
            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            collider.radius = 3;
        }
    }

    public float orcSpeed;

    private void Update()
    {
        if (isInRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, orctarget.position, orcSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, iposition.position, orcSpeed * Time.deltaTime);
        }

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
    


}

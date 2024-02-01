using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : MonoBehaviour
{
    public GameObject controlled;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            controlled.SetActive(false);
        }

    }    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            controlled.SetActive(true);
           
        }

    }
}


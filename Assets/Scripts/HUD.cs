using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public HealthCode Iframe;
    public static HUD hud;
    public bool iframepot;
    public int iframescounter;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI Iframes;
    public int coins;
    public int health;

    private void Awake()
    {
        if (hud != null && hud != this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Iframe = GameObject.FindObjectOfType<HealthCode>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Iframe.iframesTimer>1.5)
        {
            iframepot = true;
            
        }

        if (Iframe.iframesTimer <= 0)
        {
            iframepot = false;
            
        }

        if (iframepot == true)
        {
            iframescounter = Mathf.RoundToInt(Iframe.iframesTimer);
            Iframes.text = "Invincible " + iframescounter + "s";
            
        }

        if (iframepot == false)
        {
            Iframes.text = "";
        }

        coinText.text = coins.ToString();
        healthText.text = health.ToString();
    }
}
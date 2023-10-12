using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public static HUD hud;
    

    public TextMeshProUGUI coinText;

    public TextMeshProUGUI healthText;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coins.ToString();
        healthText.text = health.ToString();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public GameObject player;
    SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    private float m_Red;
    private float m_Blue;
    float m_Green;
    private int changy;
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
        m_Green = .96f;
        m_Blue = 1;
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = player.GetComponent<SpriteRenderer>();
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
            if (m_Red <= 0)
            {
                changy = 1;
            }

            if (m_Red >= 1)
            {
                changy = -1;
            }

            m_Red = m_Red+(Time.deltaTime * changy);
            m_Red = Mathf.Clamp01(m_Red);
            m_Blue = Mathf.Clamp01(m_Blue);
            m_NewColor = new Color(m_Red, m_Green, m_Blue);

            //Set the SpriteRenderer to the Color defined by the Sliders
            m_SpriteRenderer.color = m_NewColor;
        }

        if (iframepot == false)
        {
            Iframes.text = "";
            m_SpriteRenderer.color = Color.white;
        }

        coinText.text = coins.ToString();
        healthText.text = health.ToString();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer m_SpriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color m_NewColor;

    //These are the values that the Color Sliders return
    private float m_Red;
    private float m_Blue;
    float m_Green;
    private int changy;
    public HealthCode Iframe;
    // Start is called before the first frame update
    public bool iframepot;
     
    public int initialhealth;
    public int health;
    public int coins;
    public int iframescounter;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI Iframes;
    public TextMeshProUGUI healthText;
    public static HUD hud;
    void Awake()
    {
        if (hud != null && hud != this)
        {
            
            Destroy(gameObject);
            Debug.Log("Duplicate HUD found. Destroying the current instance.");
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("HUD is set to this instance.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {   player = GameObject.FindWithTag("PlayerSprite");

        m_Green = 1f;
        m_Blue = 1f;
        m_Red = 1f;
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = player.GetComponent<SpriteRenderer>();
        Iframe = GameObject.FindObjectOfType<HealthCode>();
        Iframes.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Iframe == null)
        {
            Iframe = GameObject.FindObjectOfType<HealthCode>();
        }
        if (player == null)
        {
            Debug.Log("find code ran");
              player = GameObject.FindWithTag("PlayerSprite");
              m_SpriteRenderer = player.GetComponent<SpriteRenderer>();
              
        }
        if (Iframe.iframesTimer>9.9f)
        {
            
            iframepot = true;
            if (health == 1)
            {
                ColorReset();
            }
        }

        if (Iframe.iframesTimer <= 0)
        {
            Iframes.text = "";
            if (health != 1)
            {
                ColorReset();
            }
            
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
if (health == 1)
        {
            if (iframepot == false)
            {
                
                if (m_Green <= 0)
                {
                    changy = 1;
                }

                if (m_Green >= 1)
                {
                    changy = -1;
                }

                m_Green = m_Green+ (Time.deltaTime * changy);
                m_Blue = m_Blue+ (Time.deltaTime * changy);
                m_Red = Mathf.Clamp01(m_Red);
                m_Green = Mathf.Clamp01(m_Green);
                m_Blue = Mathf.Clamp01(m_Blue);
                m_NewColor = new Color(m_Red, m_Green, m_Blue);
                Debug.Log("r= "+m_Red+" b= "+m_Blue+" g= "+m_Green);
                //Set the SpriteRenderer to the Color defined by the Sliders
                m_SpriteRenderer.color = m_NewColor;
                
            }
        }

        
                // detect a change in Iframe.iframes or health and run code
            
         
        coinText.text = "Coins= "+coins;
        healthText.text = "Health= "+health;
    }

    public void ColorReset()
    {

        if(m_SpriteRenderer != null)
        {
            m_SpriteRenderer.color = Color.white;
            //Debug.Log("r= "+m_Red+" b= "+m_Blue+" g= "+m_Green);
            m_Green = 1f;
            m_Blue = 1f;
            m_Red = 1f;

        }
               
    }
    
}

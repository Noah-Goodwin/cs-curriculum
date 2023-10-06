using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Coin coinpurse;

    public HealthCode health;

    public TextMeshProUGUI coinText;

    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinpurse.Coins.ToString();
        healthText.text = health.health.ToString();
    }
}
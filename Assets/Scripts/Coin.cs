using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CollectCoin(1);
            Destroy(other.gameObject);

        }
    }
    void CollectCoin(int amount)
    {
        hud.coins += amount;
        Debug.Log("Coins: "+hud.coins);
    }
}



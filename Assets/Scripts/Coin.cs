using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Coins += amount;
        Debug.Log("Coins: "+Coins);
    }
}



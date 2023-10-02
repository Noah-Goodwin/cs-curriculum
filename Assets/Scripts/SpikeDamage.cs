using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damageAmount = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player
        PlayerHealth Health = other.GetComponent<PlayerHealth>();
        if (Health != null)
        {
            // Apply damage to the player
            Health.TakeDamage(damageAmount);
        }
    }
}
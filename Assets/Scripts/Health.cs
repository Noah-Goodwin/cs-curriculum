
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 12;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;

            // Check if the player's health is zero or less
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
        }
    }

    private void Die()
    {
        // TODO: Implement actions to perform when the player dies (e.g., game over screen, respawn logic)

        // For this example, we'll just destroy the player object
        Destroy(gameObject);
    }

    public void Heal(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;

            // Ensure the health doesn't exceed the maximum
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
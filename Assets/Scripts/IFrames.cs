
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrames : MonoBehaviour
{
    public float invincibilityDuration = 2.0f;
    private bool isInvincible = false;
    private float invincibilityTimer = 0.0f;

    void Update()
    {
        // Update the invincibility timer if the player is invincible
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            if (invincibilityTimer <= 0.0f)
            {
                isInvincible = false;
                // TODO: Implement logic for when invincibility ends (e.g., change visuals, reset state)
            }
        }
    }

    public void TakeDamage()
    {
        if (!isInvincible)
        {
            // TODO: Implement logic for what happens when the player takes damage

            // Start invincibility
            StartInvincibility();
        }
    }

    private void StartInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
        // TODO: Implement logic for when invincibility starts (e.g., change visuals, play sound)
    }
}
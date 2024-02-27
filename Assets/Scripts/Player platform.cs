using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerplatform : MonoBehaviour
{
    public GameObject platform;  // Reference to the moving platform

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Find and set the platform (you may set this in the Unity Editor)
        //platform = GameObject.FindWithTag("MovingPlatform");
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {

            if (platform == null)
            {
                Debug.LogError("Moving platform not found. Make sure to set the correct tag or reference.");
            }
            else
            {
                // Make the player a child of the platform
                transform.SetParent(platform.transform);
            }
        }
    }

    void Update()
    {
        // Optionally, you can add additional logic here if needed
    }

    // Make sure to reset the parent when the player leaves the platform
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // Reset the parent to null (no parent)
            transform.SetParent(null);
        }
    }
}
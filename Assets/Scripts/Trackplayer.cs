using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trackplayer : MonoBehaviour
{
// Speed at which the object rotates to face the mouse
    public float rotationSpeed = 5f;

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction vector from the object to the mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the object smoothly towards the mouse
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
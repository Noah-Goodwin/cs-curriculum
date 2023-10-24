using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerTracking : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Calculate the direction to the target
        Vector2 direction = target.position - transform.position;

        // Calculate the rotation angle in radians
        float angle = Mathf.Atan2(direction.y, direction.x);

        // Calculate the new position of the follower
        Vector2 newPosition = (Vector2)transform.position + direction.normalized * Time.deltaTime;

        // Rotate the follower to face the target
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);

    }
}
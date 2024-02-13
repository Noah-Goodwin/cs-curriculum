using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject player;
    public bool isClimbing;
    public float climbSpeed;
    private Rigidbody2D playerRigidbody;
    private void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimbing = true;
            playerRigidbody.gravityScale = 0f;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimbing = false;
            playerRigidbody.gravityScale = 1f;
        }
    }

    private void Update()
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            // Adjust the player's position based on vertical input
            // You might need to tweak the values based on your game's scale
            // For example, you may want to adjust speed and use physics for smoother movement
            // Here's a simple movement without physics for demonstration purposes:
            player.transform.Translate(Vector3.up * verticalInput * climbSpeed * Time.deltaTime);
        }
    }
}

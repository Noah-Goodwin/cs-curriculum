using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // allow jumping again
        playerMovement.canJump = true;
        //player.transform.tag = "onFloor";
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //player.transform.tag = "Jumping";
        playerMovement.shouldJump = false;
        
    }
}

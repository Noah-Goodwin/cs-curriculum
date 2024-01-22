using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float WalkingSpeed;
    private float XDirection;
    private float XVector;
    private float YDirection;
    private float YVector;
    public bool Overworld;
    private bool shouldJump;
    private bool canJump;
    private Vector2 playerInput;
    public Rigidbody2D rb;
    public GameObject characters;

    
    void Start()
    { 
        //rb = character.GetComponent<Rigidbody2D>();
        WalkingSpeed = 5f;
    }


    // Update is called once per frame
    void Update()
    {
        if (Overworld)
        {
            XDirection = Input.GetAxis("Horizontal");
            XVector = XDirection * WalkingSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(XVector, 0, 0);

            YDirection = Input.GetAxis("Vertical");
            YVector = YDirection * WalkingSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(0, YVector, 0);
        }

        else
        {
            XDirection = Input.GetAxis("Horizontal");
            XVector = XDirection * WalkingSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(XVector,0,0);
            


            
            
        }
        
        if(canJump && Input.GetKeyDown(KeyCode.W))
        {
            canJump = false;
            shouldJump = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // allow jumping again
            canJump = true;
        }
    }

}
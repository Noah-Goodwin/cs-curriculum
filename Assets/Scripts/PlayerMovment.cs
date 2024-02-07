using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool Overworld;
    public float wSpeed;
    public float xDirection;
    public float xVector;
    public float yDirection;
    public bool shouldJump;
    public bool canJump;
    public float jumpSpeed;
    public float yVector;
    private Vector3 playerInput;
    public Rigidbody2D rb;
    public GameObject player;
    private float jTimer;
    public float speed = 5f;
    
    public bool jTimerRunning;
    // Start is called before the first frame update
    void Start()
    {
        wSpeed = 5f;
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()


    {

        if (Overworld)
        {
            xDirection = Input.GetAxis("Horizontal");
            xVector = xDirection * wSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(xVector, 0);

            yDirection = Input.GetAxis("Vertical");
            yVector = yDirection * wSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(0, yVector);
        }
        else

        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            }
            if(canJump && Input.GetKeyDown(KeyCode.Space))
            {
                canJump = false;
                shouldJump = true;
                jTimerReset();
                jTimerRunning = true;
            }

            if (jTimerRunning)
            {
                jTimer -= Time.deltaTime;

                if (jTimer <= 0)
                {
                    canJump = true;
                    jTimerRunning = false;
                }
                
            }

        } 

    }

    
    private void FixedUpdate()
    {
        // move
        if(playerInput != Vector3.zero) {
            rb.AddForce(playerInput * wSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
     
        // jump
        if(shouldJump)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            shouldJump = false;
        }
    }
 


    private void jTimerReset()
    {
        jTimer = 1.3f;
    }
}
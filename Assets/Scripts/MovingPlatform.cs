using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float ySpeed = 6f;
    private float originalYPosition;
    private float originalXPosition;
    public bool PlayerOn;
    private bool PlayerOff;
    private bool movedUp;
    public Transform pointT;
    public Transform pointI;
    
    
    private bool movedDown;
    // Start is called before the first frame update
    void Start()
    {
      
       
        PlayerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOn)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointT.position, ySpeed * Time.deltaTime);
            

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointI.position, ySpeed * Time.deltaTime);
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerOn = true;
            
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerOn = false;
        }
    }
    
}

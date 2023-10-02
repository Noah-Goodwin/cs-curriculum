using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float WalkingSpeed;
    private float XDirection;
    private float XVector;
    private float YDirection;
    private float YVector;
    
    void Start()
    {
        WalkingSpeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        XDirection = Input.GetAxis("Horizontal");
        XVector = XDirection * WalkingSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(XVector,0,0);
        
        YDirection = Input.GetAxis("Vertical");
        YVector = YDirection * WalkingSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(0,YVector,0);
    }
}
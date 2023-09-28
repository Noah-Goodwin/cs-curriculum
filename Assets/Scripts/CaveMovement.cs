using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavemovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float WalkingSpeed;
    private float XDirection;
    private float XVector;
    
    void Start()
    {
        WalkingSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        XDirection = Input.GetAxis("Horizontal");
        XVector = XDirection * WalkingSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(XVector,0,0);
    }
}

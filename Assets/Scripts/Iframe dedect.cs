using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iframededect : MonoBehaviour
{
    public HealthCode Iframe;
    // Start is called before the first frame update
    void Start()
    {
        Iframe = GameObject.FindObjectOfType<HealthCode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Iframe.iframes != true)
        {
            Destroy(gameObject);
            Debug.Log("item delete");
        }
    }
}

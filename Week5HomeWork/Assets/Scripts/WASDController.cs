using System;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    public bool inWeb;
    
    Rigidbody rb;

    public float forceAmount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

      
        InvokeRepeating("UnFreezePlayer", 0, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!inWeb)
        {
            if (Input.GetKey(keyUp))
            {
                rb.AddForce(Vector3.up * forceAmount);
            }

            if (Input.GetKey(keyDown))
            {
                rb.AddForce(Vector3.down * forceAmount);
            }

            if (Input.GetKey(keyLeft))
            {
                rb.AddForce(Vector3.left * forceAmount);
            }

            if (Input.GetKey(keyRight))
            {
                rb.AddForce(Vector3.right * forceAmount);
            }
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Web")
        {
            inWeb = true;
            forceAmount = 0;
           
        }
    }

    void UnFreezePlayer()
    {
        if (inWeb)
        {
            inWeb = false;
            forceAmount = 2;
        }
    }
}

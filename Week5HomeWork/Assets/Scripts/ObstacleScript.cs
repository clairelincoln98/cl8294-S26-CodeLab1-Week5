using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ObstacleScript : MonoBehaviour
{

    Rigidbody rb;
    public float forceAmount;
    public Vector2 direction;
    public int index;
    public bool hittingWall = false;
    public List<Vector2> vectorList = new List<Vector2>();
    public static ObstacleScript instance;
  
    void Start()
    {
        
        // Add vectors to the list
        rb = GetComponent<Rigidbody>();
        vectorList.Add(Vector2.up); // Shortcut for (0, 1, 0)
        vectorList.Add(Vector2.left); 
        vectorList.Add(Vector2.right); // Shortcut for (0, 1, 0)
        vectorList.Add(Vector2.down);// (0, 0, 5)
        
        InvokeRepeating("MoveObject", 0, .5f);
    }
    void Update()
    {
        
        
    }

    // void FixedUpdate()
    // {
    //     if (hittingWall)
    //     {
    //         if (direction == Vector2.up)
    //         {
    //             direction = Vector2.down;
    //         }
    //         if (direction == Vector2.down)
    //         {
    //             direction = Vector2.up;
    //         }
    //         if (direction == Vector2.left)
    //         {
    //             direction = Vector2.right;
    //         }
    //         if (direction == Vector2.right)
    //         {
    //             direction = Vector2.left;
    //         }
    //         MoveObject();
    //     }
    // }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            ASCIILevelLoader.instance.LoadLevel();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "spidercollider")
        {
            Debug.Log("collider working");
           // hittingWall = true;
        }
    }

    void MoveObject()
    {
        index = Random.Range(0, vectorList.Count);
        direction = vectorList[index];
        rb.AddForce(direction * forceAmount);
        

        // if (hittingWall)
        // {
        //     if (direction == Vector2.up)
        //     {
        //         direction = Vector2.down;
        //     }
        //
        //     if (direction == Vector2.down)
        //     {
        //         direction = Vector2.up;
        //     }
        //
        //     if (direction == Vector2.left)
        //     {
        //         direction = Vector2.right;
        //     }
        //
        //     if (direction == Vector2.right)
        //     {
        //         direction = Vector2.left;
        //     }
        // }
    }
    
}

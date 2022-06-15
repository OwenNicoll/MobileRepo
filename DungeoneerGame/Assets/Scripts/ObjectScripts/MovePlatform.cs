using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: This script will set the direction and speed of moving platforms

public class MovePlatform : MonoBehaviour
{
    public float platformSpeed;
    public Vector2 direction;

    private Rigidbody2D rb;



    void Awake()
    {
        // Get RigidBody
        rb = GetComponent<Rigidbody2D>();

        
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Platform
        rb.AddForce(direction * platformSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if platform collides with TurnPoint object
        if (collision.tag == "TurnPoint")
        {
            // Call the flip function
            Flip();
        }
    }

    void Flip()
    {
        // Reverse the speed of the platform
        platformSpeed *= -1;

    }
}

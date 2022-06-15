using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: This script will set the direction and speed of a projectile after it has been spawned

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    // Declare Variables
   
    private Rigidbody2D rigidBody;
    public float force;
    


    // Start is called before the first frame update
    void Start()
    {
        

        // Get RigidBody
        rigidBody = GetComponent<Rigidbody2D>();




        // Set velocity of projectile
        rigidBody.velocity = transform.right * force *Time.deltaTime;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if projectile collides with terrain or player
        if ((collision.tag == "Ground") || collision.tag == "Player" || (collision.tag == "Hazard"))
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}

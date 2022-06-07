using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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




        // Set velocity of projectile in direction of mouse
        rigidBody.velocity = transform.right * force;
       
    }
}

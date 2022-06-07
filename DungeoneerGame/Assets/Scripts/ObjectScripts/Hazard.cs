using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: This script will kill the player when they touch the object

public class Hazard : MonoBehaviour   
{
    // How much damage this hazard should deal
    public int hazardDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the health component from the object
        PlayerHealth healthScript = collision.gameObject.GetComponent<PlayerHealth>();


        // Check if the collided object has the health script
        if (healthScript != null)
        {
            // We hit the player!

            //healthScript.ChangeHealth(hazardDamage);
            GameObject.Destroy(collision.gameObject);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

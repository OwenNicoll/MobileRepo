using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// PURPOSE: this script will load the next level if player collides with door

public class door : MonoBehaviour
{
    // The scene we want to load
    public string targetScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if we collided with player
        if (collision.CompareTag("Player"))
        {
            // Change scene
            SceneManager.LoadScene(targetScene);

            
        }


    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Purpose: Handle player damage and death if triggered by a hazard

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;

    private int currentHealth = 100;

    public float invincibilityPeroid = 1;
    private float hitTime = 0;

    private void Awake()
    {
        // Initialise our current health
        currentHealth = startingHealth;
    }


    // Action: Kill the player
    public void Kill()
    {
        // Destroy the object THIS script is attached to 
        Destroy(gameObject);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        
    }

    // Action: Change our current health by a set amount
    public void ChangeHealth(int changeAmount)
    {
        // CONDITION: Has it been long enough since we were last damaged
        if (Time.time >= hitTime +invincibilityPeroid)
        {
            // ACTION: Deal the damage
            currentHealth += changeAmount;

            hitTime = Time.time;

            // ACTION: Lock health between 0 and starting health
            currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

            // CONDITION: if player health reaches zero
            if (currentHealth <= 0)
            {
                Kill();
            }
        }


    }

}

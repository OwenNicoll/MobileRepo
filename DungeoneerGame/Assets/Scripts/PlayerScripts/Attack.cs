using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PURPOSE: This script will allow the player to shoot projectiles

public class Attack : MonoBehaviour
{
    public GameObject knifePrefab;
    public Transform weaponTransform;
    public bool canFire = true;

    private float fireTime;
    public float fireTimeCounter;
   


    // Update is called once per frame
    void Update()
    {
        // Start timer
        fireTime += Time.deltaTime;

        // Check if enough time has passed
        if (fireTime > fireTimeCounter)
        {
            // Set canFire to true to allow player to shoot
            canFire = true;            
        }
    }

    public void Shoot()
    {
        // Check if player can shoot
        if (canFire)
        {
            // Spawn a knife object at the weaponTransform position
            Instantiate(knifePrefab, weaponTransform.position, weaponTransform.rotation);

            // Play attack sound
            FindObjectOfType<AudioManager>().Play("Throw");

            // Reset timer
            fireTime = 0;
            
            // Set canFire to false
            canFire = false;
        }
        
    }
}

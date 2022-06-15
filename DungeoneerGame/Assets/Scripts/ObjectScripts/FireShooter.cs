using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: This script will shoot projectiles from traps

public class FireShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireBall;
    public Transform weaponTransform;
   

    private float fireTime;
    public float fireTimeCounter;



    // Update is called once per frame
    void Update()
    {
        // Start timer
        fireTime += Time.deltaTime;

        // Check if enough time has passed since last shot
        if (fireTime > fireTimeCounter)
        {
            // call the shoot function
            Shoot();
        }
    }

    public void Shoot()
    {
        // Spawn a fireball object at the weaponTransform position
        Instantiate(fireBall, weaponTransform.position, weaponTransform.rotation);

        // Reset timer
        fireTime = 0;
    }
}

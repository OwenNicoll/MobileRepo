using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: This script will set speed and direction of enemies

public class EnemyMovement : MonoBehaviour
{

    public float enemySpeed;     
    public Vector2 direction;
    private int hits = 0;
    public int health = 2;
    private Rigidbody2D rb;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemySpeed in the direction
        rb.AddForce(direction * enemySpeed * Time.deltaTime);

        // Check if enemy has recieved enough hits to die
        if (hits == health)
        {
            // Destroy enemy
            Destroy(gameObject);

            // Play enemy death sound
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if enemy collides with TurnPoint
        if (collision.tag == "TurnPoint")
        {
            Flip();
        }

        // Check if enemy is hit by the players knife
        if (collision.tag == "Knife")
        {
            // Increase hit count by 1
            hits++;
        }
    }

    void Flip()
    {
        // Rotate the enemy 180° on the Y axis
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        // Reverse the enemy Speed
        enemySpeed *= -1;
        
    }

    

}

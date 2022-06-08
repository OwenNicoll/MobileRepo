using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float enemySpeed;     
    public Vector2 direction;

    private Rigidbody2D rb;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction * enemySpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TurnPoint")
        {
            Flip();
        }
    }

    void Flip()
    {
        
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        enemySpeed *= -1;
        
    }

}

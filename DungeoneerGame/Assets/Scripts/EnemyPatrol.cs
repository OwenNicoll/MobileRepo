using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public bool isPatroling;
    public Rigidbody2D rb;
    public float enemySpeed;


    // Start is called before the first frame update
    void Start()
    {
        isPatroling = false;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

     void Patrol()
    {
        rb.velocity = new Vector2(enemySpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        isPatroling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        enemySpeed *= -1;
        isPatroling = true;
    }
}

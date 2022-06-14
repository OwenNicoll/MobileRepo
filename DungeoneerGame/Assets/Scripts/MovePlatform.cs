using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float platformSpeed;
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
        rb.AddForce(direction * platformSpeed * Time.deltaTime);
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

        platformSpeed *= -1;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 50f;
    public float jumpForce = 100f;
    public float friction;
    private Button button;
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        button = GetComponent<Button>();
    }

    public void MoveLeft()
    {
        rb.AddForce(new Vector2(-moveSpeed, 0) * friction);
    }

    public void MoveRight()
    {
        rb.AddForce(new Vector2(moveSpeed, 0) * friction);
    }

    public void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-moveSpeed, 0) * friction);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(moveSpeed, 0) * friction);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

    }
}

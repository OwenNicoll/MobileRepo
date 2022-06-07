using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed = 50f;
    public float jumpForce = 100f;
    public float friction;

   public int jumpCount = 2;

    private Vector3 spawnPoint;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool facingRight = true;
    

    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        spawnPoint = transform.position;
    }

    public void MoveLeft()
    {
        rb.AddForce(new Vector2(-moveSpeed, 0) * friction);
        if (facingRight)
        {
            Flip();
        }
        
    }

    public void MoveRight()
    {
        rb.AddForce(new Vector2(moveSpeed, 0) * friction);
        if (!facingRight)
        {
            Flip();
        }
              
    }

    public void Jump()
    {
        

        if (isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpCount = 2;
        }
        else if (jumpCount > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        jumpCount--;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("JumpSpeed", Mathf.Abs(rb.velocity.y));

        


        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-moveSpeed, 0) * friction);
            if (facingRight)
            {
                Flip();
            }

                     
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(moveSpeed, 0) * friction);
            if (!facingRight)
            {
                Flip();
            }
            
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {       
            Jump();              
        }



             
    }
    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard")
        {
            transform.position = spawnPoint;
        }
        else if (collision.tag == "CheckPoint")
        {
            spawnPoint = transform.position;
        }
    }




}

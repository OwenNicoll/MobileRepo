using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

// PURPOSE: This script will allow the player to move, jump and shoot using keyboard or buttons. It will also kill and respawn the player

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

        // Play sound at start of each level
        FindObjectOfType<AudioManager>().Play("Door");
    }

    public void Reload()
    {
       Scene currentScene = SceneManager.GetActiveScene(); SceneManager.LoadScene(currentScene.name);
    }

    public void MoveLeft()
    {
        // Move the player to the left
        rb.AddForce(new Vector2(-moveSpeed, 0) * friction * Time.deltaTime);
        if (facingRight)
        {
            // Call the flip function if player is facing wrong way
            Flip();
        }
        
    }

    public void MoveRight()
    {
        // Move the player to the right
        rb.AddForce(new Vector2(moveSpeed, 0) * friction * Time.deltaTime);
        if (!facingRight)
        {
            // Call the flip function if player is facing wrong way
            Flip();
        }
              
    }

    public void Jump()
    {
        // Check if player is grounded
        if (isGrounded)
        {
            // Move the player upwards
            rb.velocity = Vector2.up * jumpForce;
            
            // Set jump count to 2
            jumpCount = 2;
            
            // Play jump sound
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        // Check if player is able to double-jump
        else if (jumpCount > 0)
        {
            // Move player upward
            rb.velocity = Vector2.up * jumpForce;

            // Play jump sound
            FindObjectOfType<AudioManager>().Play("Jump2");
        }
        // Reduce jumpcount by 1
        jumpCount--;
    }

    // Update is called once per frame
    void Update()
    {
        // Set isGrounded to true if players feet are on the ground
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        // Set animator parametors
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("JumpSpeed", Mathf.Abs(rb.velocity.y));

       
        // Allow movement using keyboard
        if (Input.GetKey(KeyCode.A))
        {           
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {       
            Jump();              
        }



             
    }
    private void Flip()
    {
        // Reverse the direction of the player
        facingRight = !facingRight;

        // Rotate the player 180 degrees on the Y axis
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player collides with hazard
        if (collision.tag == "Hazard")
        {
            // Respawn the player at spawnPoint
            transform.position = spawnPoint;

            // Play death sound
            FindObjectOfType<AudioManager>().Play("Death");

        }

        // Check if player collides with checkPoint
        else if (collision.tag == "CheckPoint")
        {
            // Set the checkpoint as the new Spawn Point
            spawnPoint = transform.position;

            // Play checkpoint sound
            FindObjectOfType<AudioManager>().Play("Checkpoint");
        }
    }




}

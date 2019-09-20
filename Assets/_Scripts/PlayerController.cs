using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimator;

    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;

    private bool attacking;
    private float attackTimer = 0f;
    private float attackCD = 0.3f;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>(); // Animation
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis("Horizontal");

        if (movement > 0f) // Right movement.
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y); // Move the player right.

            // Sprite always facing right (+ on scale).
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (movement < 0f) // Left movement.
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y); // Move the player left.

            // When going left change scale to minus to rotate sprite.
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else // No movement.
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround) // Jump
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

        playerAnimator.SetFloat("Speed", Math.Abs(rigidBody.velocity.x)); // Walking condition starts animator.
        playerAnimator.SetBool("OnGround", isTouchingGround); // Jumping condition starts animator.

        if (Input.GetKeyDown(KeyCode.LeftControl)) // Attack.
        {
            attacking = true;
            attackTimer = attackCD;
        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else { attacking = false; }
        }

        playerAnimator.SetBool("Attacking", attacking); // Starts attack animation.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector") // Fall of a platform.
        {
            //transform.position = respawnPoint;
            gameLevelManager.Respawn();
        }

        if (collision.tag == "Checkpoint") // Return to checkpoint (wooden sign).
        {
            respawnPoint = collision.transform.position;
        }

        if (collision.tag == "NextLevel")
        {
            gameLevelManager.NextLevel();
        }
    }
}
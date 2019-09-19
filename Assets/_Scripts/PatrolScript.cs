using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    // public float speed;
    private bool isMovingRight = false;

    public Transform groundDetection;
    public Transform targetPlayer;
    public Transform currentPosition;

    public float distance = 0.3f;

    [SerializeField]
    private float speed = 15f;

    private Vector2 facing = Vector2.left;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(facing * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (isMovingRight == false)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingRight = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isMovingRight = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            TurnAround();
        }

        // Turn around when player is behind but within reach of attack.
        if (collision.tag == "Player")
        {
            if ((targetPlayer.position.x < currentPosition.position.x && isMovingRight) ||
                    (targetPlayer.position.x > currentPosition.position.x && !isMovingRight))
            {
                TurnAround();
            }
        }
    }

    public void TurnAround()
    {
        facing.x *= -1;
        transform.localScale = new Vector3(facing.x * 0.4f, 0.4f, 1f);
    }
}
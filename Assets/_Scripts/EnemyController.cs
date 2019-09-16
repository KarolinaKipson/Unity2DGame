using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    public int demage;
    public bool isDead;
    private Animator enemyAnim;
    private bool isFacingRight = false;
    private Rigidbody2D enemyRigidbody;

    //private Vector3 localScale;
    private bool attacking;

    private float attackTimer = 0f;
    private float attackCD = 500f;

    // Start is called before the first frame update
    private void Start()
    {
        attacking = false;
        health = 5;
        demage = 1;
        isDead = false;
        enemyAnim = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        attackTimer = attackCD;
        //transform.Translate(Vector2.left * 5f * Time.deltaTime);
    }

    // Update is called once per frame
    private void Update()
    {
        if (attacking && health > 0)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else { attacking = false; }
        }
        //if (health == 0)
        //{
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && health > 0)
        {
            Attack();
            TakeDamage(demage);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        Attack();
    //        TakeDamage(demage);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        attacking = false;
    //        enemyAnim.SetBool("attacking", attacking);
    //    }
    //}

    public void Attack()
    {
        attacking = true;
        enemyAnim.SetBool("attacking", attacking);
        attackTimer = attackCD;
    }

    public void TakeDamage(int demage)
    {
        if (health > 0)
        {
            health -= demage;
            Debug.Log("Damage taken!");
        }
        else
        {
            attacking = false;
            isDead = true;
            enemyAnim.SetBool("isDead", isDead);
            Destroy(gameObject);
        }
    }
}
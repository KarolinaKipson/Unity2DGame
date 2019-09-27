using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float cHealth;
    public float maxHealth;
    public float demage;
    public float playerDemage;
    public bool isDead;
    private Animator enemyAnim;

    private bool attacking;
    private float attackTimer = 0f;
    private float attackCD = 1f;

    public Slider healthBar;

    public PlayerController player;

    // Start is called before the first frame update
    private void Start()
    {
        //maxHealth = 5f;
        cHealth = maxHealth;
        //demage = 1f;
        attacking = false;
        isDead = false;
        enemyAnim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        attackTimer = attackCD;
        healthBar.value = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else if (attackTimer <= 0)
            {
                attacking = false;
                enemyAnim.SetBool("attacking", attacking);
                //FindObjectOfType<AudioManager>().Stop("Attack");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Attack();

            if (player.attacking)
            {
                TakeDamage(demage);
            }
        }
    }

    public void Attack()
    {
        attackTimer = attackCD;
        attacking = true;
        //FindObjectOfType<AudioManager>().Play("Attack");
        enemyAnim.SetBool("attacking", attacking);
    }

    public void TakeDamage(float demage)
    {
        cHealth -= demage * Time.deltaTime;

        healthBar.value = cHealth;

        if (cHealth <= 0)
        {
            StartCoroutine("Death");
        }
    }

    public IEnumerator Death()
    {
        isDead = true;
        enemyAnim.SetBool("isDead", isDead);
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");
        yield return new WaitForSeconds(0.58f);
        Destroy(gameObject);
    }
}
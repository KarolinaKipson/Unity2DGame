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
    public bool isDead;
    private Animator enemyAnim;

    private bool attacking;
    private float attackTimer = 0f;
    private float attackCD = 1f;

    public Slider healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        maxHealth = 5f;
        cHealth = maxHealth;
        demage = 1f;
        attacking = false;
        isDead = false;
        enemyAnim = GetComponent<Animator>();
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
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Attack();
            TakeDamage(demage);
        }
    }

    public void Attack()
    {
        attackTimer = attackCD;
        attacking = true;
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

        yield return new WaitForSeconds(0.58f);
        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float cHealth;
    public float maxHealth;
    public float demage;
    public bool isDead;
    private Animator enemyAnim;
    private Rigidbody2D enemyRigidbody;
    private float speed;

    public Transform target;
    public Transform currentPosition;
    private bool attacking;

    private float attackTimer = 0f;
    private float attackCD = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        maxHealth = 5f;
        cHealth = maxHealth;
        speed = 3f;
        demage = 1f;
        attacking = false;
        isDead = false;
        enemyAnim = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        attackTimer = attackCD;
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

            //Turn to player when attacking???
            //if (target.position.x < currentPosition.position.x)
            //{
            //    //enemyRigidbody.velocity = new Vector2(-1 * speed, enemyRigidbody.velocity.y);

            //    transform.localScale = new Vector2(-Mathf.Abs(currentPosition.localScale.x), currentPosition.localScale.y);
            //}
            //else if (target.position.x > currentPosition.position.x)
            //{
            //    // enemyRigidbody.velocity = new Vector2(1 * speed, enemyRigidbody.velocity.y);

            //    transform.localScale = new Vector2(Mathf.Abs
            //        (currentPosition.localScale.x), currentPosition.localScale.y);
            //}
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
        cHealth -= demage * Time.deltaTime; //
        Debug.Log("Damage taken!");

        if (cHealth <= 0)
        {
            StartCoroutine("Death");
        }
    }

    public IEnumerator Death()
    {
        isDead = true;
        enemyAnim.SetBool("isDead", isDead);

        yield return new WaitForSeconds(0.57f);
        Destroy(gameObject);
    }
}
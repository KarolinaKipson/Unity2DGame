using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float cHealth;
    public float maxHealth;
    public float damage;
    public bool isDead;

    private Animator playerAnim;

    public Slider healthBar;
    public int numLives;

    public LevelManager gameLevelManager;
    public EnemyController playerDemage;

    private bool isRunning;

    // Start is called before the first frame update
    private void Start()
    {
        //enemy 0.5 points, medicine, poison 1 point
        maxHealth = 10f;
        cHealth = maxHealth;
        isDead = false;
        playerAnim = GetComponent<Animator>();
        playerAnim.enabled = true;
        //isRunning = false;
        healthBar.value = maxHealth;
        gameLevelManager = FindObjectOfType<LevelManager>();
        playerDemage = FindObjectOfType<EnemyController>();
        numLives = 5;
        PlayerPrefs.SetInt("Lives", numLives);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            damage = playerDemage.playerDemage;
            StartCoroutine(TakeDamage(damage));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Poison")
        {
            StartCoroutine(TakeDamage(damage));
        }

        if (collision.tag == "Medicine")
        {
            IncreaseHealth(damage);
        }
    }

    public void IncreaseHealth(float demage)
    {
        cHealth += demage;

        healthBar.value = cHealth;
        if (cHealth > maxHealth)
        {
            cHealth = maxHealth;
        }
    }

    public IEnumerator TakeDamage(float demage)
    {
        cHealth -= demage;

        healthBar.value = cHealth;

        if (cHealth <= 0f)
        {
            cHealth = 0;
            healthBar.value = cHealth;
            yield return StartCoroutine(DeathAnim());

            gameLevelManager.AfterDeath();
        }
    }

    public IEnumerator DeathAnim()
    {
        isDead = true;
        playerAnim.SetBool("Dead", isDead);

        yield return new WaitForSeconds(1.2f);
    }
}
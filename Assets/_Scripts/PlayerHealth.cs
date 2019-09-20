using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float cHealth;
    public float maxHealth;
    public float demage;
    public bool isDead;

    private Animator playerAnim;

    public Slider healthBar;
    public int numLives;

    public LevelManager gameLevelManager;

    // Start is called before the first frame update
    private void Start()
    {
        //enemy 0.5 points, medicine, poison 1 point
        maxHealth = 10f;
        cHealth = maxHealth;
        demage = 25f;
        isDead = false;
        playerAnim = GetComponent<Animator>();
        healthBar.value = maxHealth;
        gameLevelManager = FindObjectOfType<LevelManager>();
        numLives = 5;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            TakeDamage(demage);
        }

        if (collision.tag == "Poison")
        {
            TakeDamage(demage);
        }

        if (collision.tag == "Medicine")
        {
            IncreaseHealth(demage);
        }
    }

    public void IncreaseHealth(float demage)
    {
        cHealth += demage * Time.deltaTime;

        healthBar.value = cHealth;
        if (cHealth > maxHealth)
        {
            cHealth = maxHealth;
        }
    }

    public void TakeDamage(float demage)
    {
        cHealth -= demage * Time.deltaTime;

        healthBar.value = cHealth;
        if (cHealth <= 0)
        {
            cHealth = 0;
            Death();
        }
    }

    public void Death()
    {
        numLives -= 1;
        PlayerPrefs.SetInt("Lives", numLives);
        isDead = true;
        playerAnim.SetBool("isDead", isDead);

        gameObject.SetActive(false);

        gameLevelManager.AfterDeath();

        cHealth = maxHealth;
        healthBar.value = cHealth;
    }
}
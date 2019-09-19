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

    // Start is called before the first frame update
    private void Start()
    {
        maxHealth = 10f;
        cHealth = maxHealth;
        demage = 25f;
        isDead = false;
        playerAnim = GetComponent<Animator>();
        healthBar.value = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy")
    //    {
    //        TakeDamage(demage);
    //    }
    //}

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
            StartCoroutine("Death");
        }
    }

    public IEnumerator Death()
    {
        isDead = true;
        playerAnim.SetBool("isDead", isDead);

        yield return new WaitForSeconds(0.58f);
        Destroy(gameObject);
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    private Animator anim;
    private GameObject player;

    // private PlayerHealth playerHealth;
    // private EnemyHealth enemyHealth;
    private bool playerInRange;

    private float timer;
    private bool isDead;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    //private void Update()
    //{
    //    timer += Time.deltaTime;

    //    if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
    //    {
    //        Attack();
    //    }

    //    if (playerHealth.currentHealth <= 0)
    //    {
    //        isDead = true;
    //        anim.SetBool("PlayerDead", isDead);
    //    }
    //}

    //private void Attack()
    //{
    //    timer = 0f;

    //    if (playerHealth.currentHealth > 0)
    //    {
    //        playerHealth.TakeDamage(attackDamage);
    //    }
    //}
}
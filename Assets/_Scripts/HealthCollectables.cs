using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectables : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int demage;

    // Start is called before the first frame update
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth.IncreaseHealth(demage);
            FindObjectOfType<AudioManager>().PlayOneShot("Collectables");
            Destroy(gameObject);
        }
    }
}
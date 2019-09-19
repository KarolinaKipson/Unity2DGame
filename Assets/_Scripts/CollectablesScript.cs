using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    private PlayerHealth health;

    // Start is called before the first frame update
    private void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
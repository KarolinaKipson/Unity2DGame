using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    private LevelManager gameLevelManager;
    private PlayerHealth playerHealth;
    public int collectableValue;

    // Start is called before the first frame update
    private void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameLevelManager.AddDiamonds(collectableValue);
            //FindObjectOfType<AudioManager>().PlayOneShot("Collectables");
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondScript : MonoBehaviour
{
    private LevelManager gameLevelManager;
    public int diamondValue;

    // Start is called before the first frame update
    private void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.up * -40);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameLevelManager.AddDiamonds(diamondValue);
            Destroy(gameObject);
        }
        // Debug.Log("Triggered");
    }
}
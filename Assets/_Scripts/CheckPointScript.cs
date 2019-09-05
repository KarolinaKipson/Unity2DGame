using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public Sprite woodenSign;
    public Sprite scroll;
    public Sprite potion;
    public Sprite tresaureChest;

    // private SpriteRenderer checkpointSpriteRenderer;
    private bool CheckpointReached;

    // Start is called before the first frame update
    private void Start()
    {
        // checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CheckpointReached = true;
        }
    }
}
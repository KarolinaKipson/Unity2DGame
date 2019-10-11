using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WitchController : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    private void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(4f, 4f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-4f, 4f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Witch");
        }
    }
}
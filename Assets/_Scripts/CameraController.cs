using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;

    public bool bounds;
    private Vector3 playerPosition;

    public Vector3 minPosition;
    public Vector3 maxPosition;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Following player.
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f) // Left
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else // Right
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        // Camera constraints.
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y), Mathf.Clamp(transform.position.z, minPosition.z, maxPosition.z));
        }

        // Smooth transfer Camera left and right.
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay = 5f;
    public PlayerController gamePlayer;
    public int diamonds;
    public TMP_Text diamondText;
    public TMP_Text levelText;

    // Start is called before the first frame update
    private void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        DisplayScore();
        DisplayLevel();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCorutine");
    }

    public IEnumerator RespawnCorutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }

    public void AddDiamonds(int numOfDiamonds)
    {
        diamonds += numOfDiamonds;
        DisplayScore();
    }

    public void DisplayScore()
    {
        diamondText.text = "Score: " + diamonds;
    }

    public void DisplayLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level: " + level;
    }
}
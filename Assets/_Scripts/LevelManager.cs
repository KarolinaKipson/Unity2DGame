using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;

    public PlayerController gamePlayer;
    public PlayerHealth playerHealth;
    public int numLives;

    public int diamonds;
    public TMP_Text diamondText;

    public TMP_Text levelText;
    public int nextLevelScore;
    public GameObject nextlevelPrefab;
    public int levelIndex;

    public TMP_Text highscoreText;

    public int highScore;

    // Start is called before the first frame update
    private void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        numLives = PlayerPrefs.GetInt("Lives", 5);
        diamonds = PlayerPrefs.GetInt("Score", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        levelIndex = PlayerPrefs.GetInt("Level", 1);
        DisplayScore();
        DisplayLevel();
        DisplayHighScore();
        nextlevelPrefab.SetActive(false);
        respawnDelay = 2f;
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

        PlayerPrefs.SetInt("Score", diamonds);

        if (diamonds > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", diamonds);
            DisplayHighScore();
        }

        if (diamonds >= nextLevelScore)
        {
            nextlevelPrefab.SetActive(true);
        }
    }

    public void DisplayScore()
    {
        diamondText.text = "Score: " + diamonds;
    }

    public void DisplayHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highscoreText.text = "Highscore: " + highScore;
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");
    }

    public void ResetLives()
    {
        PlayerPrefs.DeleteKey("Lives");
    }

    public void DisplayLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Level", level);
        levelText.text = "Level: " + level;
    }

    public void NextLevel()
    {
        int level = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(level + 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
        ResetScore();
        ResetLives();
    }

    public void AfterDeath() //GameOver or not?
    {
        numLives = PlayerPrefs.GetInt("Lives");
        if (numLives <= 0)
        {
            GameOver();
        }
        else
        {
            Debug.Log(numLives);
            Respawn();
        }
    }
}
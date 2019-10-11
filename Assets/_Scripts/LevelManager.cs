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
    public TMP_Text livesText;

    public int diamonds;
    public TMP_Text diamondText;

    public TMP_Text levelText;
    public int nextLevelScore;
    public GameObject nextlevelPrefab;
    public int levelIndex;

    public TMP_Text highscoreText;
    public int highScore;

    public TextMeshProUGUI instructions;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    private void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        numLives = PlayerPrefs.GetInt("Lives");
        diamonds = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        levelIndex = PlayerPrefs.GetInt("Level", 1);
        DisplayScore();
        DisplayLevel();
        DisplayHighScore();
        DisplayLives();
        instructions.enabled = true;
        nextlevelPrefab.SetActive(false);
        respawnDelay = 3f;
    }

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(Instructions());
    }

    public IEnumerator RespawnCorutine()
    {
        yield return new WaitForSeconds(respawnDelay);

        gamePlayer.transform.position = gamePlayer.respawnPoint;

        gamePlayer.gameObject.SetActive(true);

        playerHealth.cHealth = playerHealth.maxHealth;
        playerHealth.healthBar.value = playerHealth.cHealth;
    }

    public void AddDiamonds(int numOfDiamonds)
    {
        diamonds += numOfDiamonds;

        PlayerPrefs.SetInt("Score", diamonds);
        DisplayScore();

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

    public IEnumerator Instructions()
    {
        yield return new WaitForSeconds(10f);
        instructions.enabled = false;
    }

    public void DisplayScore()
    {
        diamonds = PlayerPrefs.GetInt("Score");
        diamondText.text = "Score: " + diamonds;
    }

    public void DisplayHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highscoreText.text = "Highscore: " + highScore;
    }

    public void DisplayLives()
    {
        numLives = PlayerPrefs.GetInt("Lives");
        livesText.text = "Lives: " + numLives;
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");
    }

    public void ResetLives()
    {
        PlayerPrefs.SetInt("Lives", 5);
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
        SceneManager.LoadScene(5);
        //ResetScore(); Decided to keep the score if game is over and lives lost but more levels coming.
        ResetLives();
    }

    public void AfterDeath() // GameOver or Respawn
    {
        numLives -= 1;
        PlayerPrefs.SetInt("Lives", numLives);
        FindObjectOfType<AudioManager>().Play("PlatformFall");

        if (numLives > 0)
        {
            DisplayLives();
            gamePlayer.gameObject.SetActive(false);
            StartCoroutine(RespawnCorutine());
        }
        else
        {
            numLives = 0;
            gamePlayer.gameObject.SetActive(false);
            GameOver();
        }
    }
}
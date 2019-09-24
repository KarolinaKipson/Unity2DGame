using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text highscoreText;

    private int highScore;
    private AudioManager instance;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().Stop("MainTheme");
        FindObjectOfType<AudioManager>().Play("GameOverTheme");
    }

    private void Start()
    {
        ResetScore();
        ResetLives();
        DisplayHighScore();
    }

    public void Restart()
    {
        int level = PlayerPrefs.GetInt("Level");
        FindObjectOfType<AudioManager>().Stop("GameOverTheme");
        SceneManager.LoadScene(level);
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Stop("GameOverTheme");
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        DisplayHighScore();
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");
    }

    public void ResetLives()
    {
        // PlayerPrefs.DeleteKey("Lives");
        PlayerPrefs.SetInt("Lives", 5);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Stop("GameOverTheme");
        Application.Quit();
    }

    public void DisplayHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "Highscore: " + highScore;
    }
}
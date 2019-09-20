using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text highscoreText;

    private int highScore;

    private void Start()
    {
        ResetScore();
        ResetLives();
        DisplayHighScore();
    }

    public void Restart()
    {
        int level = PlayerPrefs.GetInt("Level");

        SceneManager.LoadScene(level);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
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
        PlayerPrefs.DeleteKey("Lives");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisplayHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "Highscore: " + highScore;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScript : MonoBehaviour
{
    public TMP_Text highscoreText;

    private int highScore;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().Stop("MainTheme");
        FindObjectOfType<AudioManager>().Play("WinTheme");
    }

    private void Start()
    {
        ResetScore();
        ResetLives();
        DisplayHighScore();
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Stop("WinTheme");
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Stop("WinTheme");
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
        //FindObjectOfType<AudioManager>().Stop("WinTheme");
        Application.Quit();
    }

    public void DisplayHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "Highscore: " + highScore;
    }
}
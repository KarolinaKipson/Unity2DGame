using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // SceneManager.LoadScene("LevelOne"); by name
        // Load level 1;
        ResetScore();
        ResetLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");
    }

    public void ResetLives()
    {
        PlayerPrefs.DeleteKey("Lives");
    }
}
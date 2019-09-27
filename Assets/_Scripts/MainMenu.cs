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
        //FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    public void QuitGame()
    {
        //FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
        Application.Quit();
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");
    }

    public void ResetLives()
    {
        PlayerPrefs.SetInt("Lives", 5);
    }
}
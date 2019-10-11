using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // Toggle pause with escape.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        // Show PauseMenu, pause game.
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if (!isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        isPaused = false;
    }

    public void Restart()
    {
        ResetLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(Application.loadedLevel); -> depricated
    }

    public void MainMenu()
    {
        ResetScore();
        FindObjectOfType<AudioManager>().Stop("MainTheme");
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
    }

    public void Quit()
    {
        ResetScore();
        FindObjectOfType<AudioManager>().Stop("MainTheme");
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
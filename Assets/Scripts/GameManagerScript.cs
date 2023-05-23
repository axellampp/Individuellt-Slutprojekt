using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseMenu;
    public GameObject SettingsMenu;
    public GameObject Background;
    public static bool isPaused;
    public static GameManagerScript instance;
    public bool settingsMenuActive;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Background.SetActive(true);
        SettingsMenu.SetActive(false);
        settingsMenuActive = false;
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if(gameOverUI.activeInHierarchy || pauseMenu.activeInHierarchy || SettingsMenu.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        {
            if (Input.GetKeyDown(KeyCode.Escape) && playerHealth.isDead == false && settingsMenuActive == false)
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }

    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void settings()
    {
        SettingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenuActive = true;
        gameOverUI.SetActive(false);
    }

    public void BackToMenu()
    {
        SettingsMenu.SetActive(false);
       // pauseMenu.SetActive(true);
        settingsMenuActive = false;
        
        if(playerHealth.isDead == true)
        {
            pauseMenu.SetActive(false);
            gameOverUI.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
    }

    private void Awake()
    {
        instance = this;
    }

}

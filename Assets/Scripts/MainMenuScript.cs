using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject BG;
    public GameObject SettingsMenu;

    void Start()
    {
        MainMenu.SetActive(true);
        BG.SetActive(true);
        SettingsMenu.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Start");
    }

    public void Settings()
    {
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exiting");
    }

}

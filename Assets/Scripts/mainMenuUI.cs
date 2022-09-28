using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class mainMenuUI : MonoBehaviour
{
    public GameObject settingsMenuUI;
    public GameObject mainMenu;

    public AudioMixer audioMixer;
    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSettings()
    { 
        settingsMenuUI.SetActive(true);
    }

    public void BackButton()
    {
        settingsMenuUI.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }
}

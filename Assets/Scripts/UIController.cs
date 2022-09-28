using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

[System.Serializable]
public class UIController : MonoBehaviour
{
    //This script controls everything I want to appear on the UI. 
    public static int health = 3;
    public Text healthText;

    public static int collectable = 0;
    public Text collectableText;
    
    public float timeRemaining;
    public bool timerIsRunning;
    public Text timeText;

    public Text instructions;
    private bool instructionsVisible;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public static bool settingsActive = false;
    public GameObject settingsMenuUI;

    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = DeployAstral.changeValue;
        //instructionsVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //sets the text of the Text UI object created to whatever value health is set as. In another script the value of health will be altered.
        healthText.text = " " + health;
        collectableText.text = " " + collectable;

        if(health <= 0) //essentially if the player dies it reloads the scene
        {
            SceneManager.LoadScene((0));
            health = 3;
        }

        if(DeployAstral.astralAlive == true) //only displays the countdown and runs it when the astral is spawned
        {
            timerIsRunning = true;
            timeText.gameObject.SetActive(true);
        } else
        { //else it is disabled
            timerIsRunning = false;
            timeText.gameObject.SetActive(false);
            timeRemaining = DeployAstral.changeValue;
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; //depletes time by 1 sec
                DisplayTime(timeRemaining);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{00}", seconds); //displays the time in this format. Mine will never exceed two digits 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackButton()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}

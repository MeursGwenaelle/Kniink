using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] private MonoBehaviour playerControlerScript;

    public GameObject pauseMenuUI;

    public GameObject settingsWindow;


    public void Start()
    {
        playerControlerScript.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }


   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }

        }
    }

    public void Paused()
    {
        playerControlerScript.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        playerControlerScript.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);

    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject helpScreen;
    public GameObject pauseMenuUI;

    public AudioClip clip;
    public AudioClip close;
    AudioSource audioSource;

    void Start ()
    {
        helpScreen = GameObject.Find("HelpScreenPNG");
         helpScreen.SetActive(false);
         audioSource = GetComponent<AudioSource>();
    }

    public void PauseGame()
    {
         
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

      public void HelpMenuOpen ()
    {
        helpScreen.SetActive(true);
        audioSource.PlayOneShot(clip, 0.7F);
    }
     public void HelpMenuClose ()
    {
        helpScreen.SetActive(false);
        audioSource.PlayOneShot(close, 0.7F);
    }

}
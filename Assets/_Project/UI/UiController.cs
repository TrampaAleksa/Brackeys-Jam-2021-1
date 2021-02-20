using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public GameObject pausePanel;
    
    public GameObject musicButtonOn;
    public GameObject musicButtonOff;

    public AudioMixer audioMixer;

    public bool isInGame;

    [ContextMenu("Stop time")]
    public void StopTime()
    {
        Time.timeScale = 0;
        AudioHolder.Instance.PauseAllSounds();
    }

    [ContextMenu("Unstop time")]

    public void UnstopTime()
    {
        Time.timeScale = 1;
        AudioHolder.Instance.UnPauseAllSounds();
    }

    public void ResumeGame()
    {
        UnstopTime();
        pausePanel.SetActive(false);
    }
    
    public void PauseGame()
    {
        UnstopTime();
        pausePanel.SetActive(true);
    }

    [ContextMenu("toggle sound off")]
    public void ToggleSoundOff()
    {
        musicButtonOn.SetActive(false);
        musicButtonOff.SetActive(true);
        audioMixer.SetFloat("MasterVolume", -80);
    }
    
    [ContextMenu("toggle sound on")]
    public void ToggleSoundOn()
    {
        musicButtonOn.SetActive(true);
        musicButtonOff.SetActive(false);
        audioMixer.SetFloat("MasterVolume", 0);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isInGame) return;
                PauseGame();
        }
    }
}

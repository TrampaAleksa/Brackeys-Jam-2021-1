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
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
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
}

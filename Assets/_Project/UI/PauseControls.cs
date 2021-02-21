using UnityEngine;

public class PauseControls : MonoBehaviour
{
    public GameObject pausePanel;
    
    [ContextMenu("Stop time")]
    public void StopTime()
    {
        Time.timeScale = 0;
        AudioHolder.Instance.PauseAllSounds();
    }

    
    public void PauseGame()
    {
        StopTime();
        pausePanel.SetActive(true);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
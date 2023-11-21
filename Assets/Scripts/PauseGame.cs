using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Button pauseBtn;
    public Button resumeBtn;

    public Canvas gameCanvas;
    public Canvas pauseCanvas;

    private bool isPaused = false;
    void Start()
    {
        pauseBtn.onClick.AddListener(Pause);
        resumeBtn.onClick.AddListener(Pause);
    }

    void Pause()
    {
        if (!isPaused)
        {   
            gameCanvas.gameObject.SetActive(false);
            pauseCanvas.gameObject.SetActive(true);
            isPaused = true;
        }
        else
        {
            gameCanvas.gameObject.SetActive(true);
            pauseCanvas.gameObject.SetActive(false);
            isPaused=false;
        }
        Time.timeScale = isPaused ? 0 : 1;
    }
}

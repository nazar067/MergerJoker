using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public AudioSource btnSound;

    public Button startBtn;
    public Canvas mainCanvas;
    public Canvas loadingCanvas;
    void Start()
    {
        Time.timeScale = 1;
        startBtn.onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        btnSound.Play();
        mainCanvas.gameObject.SetActive(false);
        loadingCanvas.gameObject.SetActive(true);
        Loading.Instance.check = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startBtn;
    public Canvas mainCanvas;
    public Canvas gameCanvas;
    void Start()
    {
        startBtn.onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        mainCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
    }
}

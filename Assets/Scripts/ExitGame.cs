using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button exitBtn;
    void Start()
    {
        exitBtn.onClick.AddListener(Exitgame);
    }

    private void Exitgame()
    {
        Application.Quit();
    }
}

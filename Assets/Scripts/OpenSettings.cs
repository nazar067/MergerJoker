using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour
{
    public AudioSource btnSound;

    public Button settingsBtn;
    public Canvas mainCanvas;
    public Canvas settingsCanvas;
    void Start()
    {
        settingsBtn.onClick.AddListener(Settings);
    }

    private void Settings()
    {
        btnSound.Play();
        mainCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(true);
    }
}

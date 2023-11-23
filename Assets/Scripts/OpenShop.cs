using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    public AudioSource btnSound;

    public Button shopBtn;
    public Canvas mainCanvas;
    public Canvas shopCanvas;
    void Start()
    {

        shopBtn.onClick.AddListener(OpShop);
    }

    private void OpShop()
    {
        btnSound.Play();
        mainCanvas.gameObject.SetActive(false);
        shopCanvas.gameObject.SetActive(true);
    }
}

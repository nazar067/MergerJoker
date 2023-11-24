using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    public static OpenShop Instance;
    
    public AudioSource btnSound;

    public Button shopBtn;
    public Canvas mainCanvas;
    public Canvas shopCanvas;

    public GameObject MenuBG;
    public GameObject ShopBG;
    void Start()
    {

        shopBtn.onClick.AddListener(OpShop);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void OpShop()
    {
        btnSound.Play();
        mainCanvas.gameObject.SetActive(false);
        shopCanvas.gameObject.SetActive(true);

        MenuBG.SetActive(false);
        ShopBG.SetActive(true);
    }
}

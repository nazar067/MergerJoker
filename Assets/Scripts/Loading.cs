using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public static Loading Instance;

    public Canvas loadingCanvas;
    public Canvas gameCanvas;

    public GameObject BGLoading;
    public GameObject BGGame;

    public bool check = false;
    void Update()
    {
        if (check)
        {
            StartCoroutine(Load());
            check = false;
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public IEnumerator Load()
    {
        yield return new WaitForSeconds(2.2f);
        loadingCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
        BGGame.gameObject.SetActive(true);
        BGLoading.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public static Loading Instance;

    public Canvas loadingCanvas;
    public Canvas gameCanvas;

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
    }
}

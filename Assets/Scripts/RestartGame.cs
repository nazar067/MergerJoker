using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public Button restartBtn;
    public AudioSource btnSound;
    void Start()
    {
        restartBtn.onClick.AddListener(Restart);
    }

    void Restart()
    {
        btnSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

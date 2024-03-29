using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    public float gameTime = 60f; 
    private float timer;           
    private bool gameEnded = false; 

    public Text timerText;

    public AudioSource loseSound;

    public Canvas gameCanvas;
    public Canvas gameEndCanvas;

    public Button plusTime;
    void Start()
    {
        timer = gameTime;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        if (!gameEnded)
        {
            timer -= Time.deltaTime;
            if(timer < 20f)
            {
                ScaleAnim anim = plusTime.GetComponent<ScaleAnim>();
                anim.enabled = true;
            }
            if (timer <= 0f)
            {
                EndGame();
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int seconds = Mathf.CeilToInt(timer);

        timerText.text = seconds.ToString() + "s";
    }

    public void EndGame()
    {
        gameEnded = true;

        loseSound.Play();
        gameCanvas.gameObject.SetActive(false);
        gameEndCanvas.gameObject.SetActive(true);

        Debug.Log("Game Over!");
    }
    public void AddMinute()
    {
        timer += 20f;
    }
}


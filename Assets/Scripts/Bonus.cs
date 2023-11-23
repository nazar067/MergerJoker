using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public static Bonus Instance;

    public Button healthBtn;
    public Button scoreBtn;
    public Button timeBtn;

    public Text scoreCount, healthCount, timeCount;
    public Text scoreCountGame, healthCountGame, timeCountGame;

    public int health;
    public int score;
    public int time;

    public AudioSource btnSound;

    void Start()
    {
        UpdateTextCount();
        healthBtn.onClick.AddListener(AddHealth);
        scoreBtn.onClick.AddListener(DoubleScore);
        timeBtn.onClick.AddListener(AddTime);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        health = PlayerPrefs.GetInt("health", 1);
        score = PlayerPrefs.GetInt("score", 1);
        time = PlayerPrefs.GetInt("time", 1);
    }

    void AddHealth()
    {
        if(health > 0 && PutCards.Instance.hp < 3)
        {
            btnSound.Play();
            PutCards.Instance.hp++;
            health--;
            PlayerPrefs.SetInt("health", health);
            UpdateTextCount();
        }
    }
    void DoubleScore()
    {
        if(score > 0 && Score.Instance.score > 0)
        {
            btnSound.Play();
            Score.Instance.score *= 2;
            Score.Instance.UpdateTextScore();
            score--;
            PlayerPrefs.SetInt("score", score);
            UpdateTextCount();
        }
    }
    void AddTime()
    {
        if(time > 0)
        {
            btnSound.Play();
            Timer.Instance.AddMinute();
            time--;
            PlayerPrefs.SetInt("time", time);
            UpdateTextCount();
        }
        
    }
    public void UpdateTextCount()
    {
        scoreCount.text = score.ToString() + "/3";
        healthCount.text = health.ToString() + "/3";
        timeCount.text = time.ToString() + "/3";

        scoreCountGame.text = score.ToString() + "/3";
        healthCountGame.text = health.ToString() + "/3";
        timeCountGame.text = time.ToString() + "/3";
    }
}

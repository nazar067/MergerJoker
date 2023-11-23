using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop Instance;

    public AudioSource buySound;


    public Button buyHealthBtn, buyScoreBtn, buyTimeBtn;
    void Start()
    {
        buyHealthBtn.onClick.AddListener(buyHealth);
        buyScoreBtn.onClick.AddListener(buyScore);
        buyTimeBtn.onClick.AddListener(buyTime);

        Bonus.Instance.UpdateTextCount();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void buyHealth()
    {
        if(Bonus.Instance.health < 3 && Money.Instance.money >= 50)
        {
            buySound.Play();
            Bonus.Instance.health++;
            Bonus.Instance.UpdateTextCount();
            PlayerPrefs.SetInt("health", Bonus.Instance.health);
            Money.Instance.MinusMoney();
        }
    }
    void buyScore()
    {
        if (Bonus.Instance.score < 3 && Money.Instance.money >= 50)
        {
            buySound.Play();
            Bonus.Instance.score++;
            Bonus.Instance.UpdateTextCount();
            PlayerPrefs.SetInt("score", Bonus.Instance.score);
            Money.Instance.MinusMoney();
        }
    }
    void buyTime()
    {
        if (Bonus.Instance.time < 3 && Money.Instance.money >= 50)
        {
            buySound.Play();
            Bonus.Instance.time++;
            Bonus.Instance.UpdateTextCount();
            PlayerPrefs.SetInt("time", Bonus.Instance.time);
            Money.Instance.MinusMoney();
        }
    }
}

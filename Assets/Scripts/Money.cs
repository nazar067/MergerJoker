using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static Money Instance;

    public Text moneyText;
    public Text gameMoneyText;
    public Text endMoneyText;
    public int money = 0;
    private void Start()
    {
        UpdateTextMoney();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        money = PlayerPrefs.GetInt("money", 0);
    }
    public void AddMoney()
    {
        if(money < 99)
        {
            money += Random.Range(3, 10);
            UpdateTextMoney();
            PlayerPrefs.SetInt("money", money);
        }
        else if(money > 99)
        {
            money = 99;
            PlayerPrefs.SetInt("money", money);
        }

    }
    public void MinusMoney() 
    {
        money -= 50;
        UpdateTextMoney();
        PlayerPrefs.SetInt("money", money);
    }
    public void UpdateTextMoney()
    {
        moneyText.text = money.ToString("F0");
        gameMoneyText.text = money.ToString("F0");
        endMoneyText.text = "Money: " + money.ToString("F0");
    }
}

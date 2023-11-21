using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public Button healthBtn;
    public Button scoreBtn;
    public Button timeBtn;
    void Start()
    {
        healthBtn.onClick.AddListener(AddHealth);
        scoreBtn.onClick.AddListener(DoubleScore);
        timeBtn.onClick.AddListener(AddTime);
    }

    void AddHealth()
    {
        PutCards.Instance.hp++;
    }
    void DoubleScore()
    {
        Score.Instance.score *= 2;
        Score.Instance.UpdateTextScore();
    }
    void AddTime()
    {
        Timer.Instance.AddMinute();
    }
}

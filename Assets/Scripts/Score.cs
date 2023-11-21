using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public Text scoreText;
    public Text endGameScoreText;
    public int score = 0;
    private void Start()
    {
        UpdateTextScore();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void AddScore()
    {
        score++;
        UpdateTextScore();
    }
    public void UpdateTextScore()
    {
        scoreText.text = score.ToString("F0");
        endGameScoreText.text = "Your score" + "\n" + score.ToString("F0");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public AudioSource scoreSound;

    public Text scoreText;
    public Text endGameScoreText;
    public int score = 0;

    public Button doubleScore;
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
        scoreSound.Play();
        score++;
        UpdateTextScore();
        if(score > 4)
        {
            ScaleAnim anim = doubleScore.GetComponent<ScaleAnim>();
            anim.enabled = true;
        }
    }
    public void UpdateTextScore()
    {
        scoreText.text = score.ToString("F0");
        endGameScoreText.text = "Score:" + " " + score.ToString("F0");
    }
}

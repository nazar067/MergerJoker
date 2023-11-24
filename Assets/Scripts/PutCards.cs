using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PutCards : MonoBehaviour
{
    public static PutCards Instance;

    public Button firstDeck;
    public Button secondDeck;

    public Button plusHeart;

    public AudioSource cardSound;
    public AudioSource minusHpSound;

    public Image randCard;
    public Image previousCard;
    public Image jokerCard;

    public Image hp1, hp2, hp3;

    public Sprite[] cards = new Sprite[13];

    public Sprite jokerSprite;
    public Sprite emptyHeart;
    public Sprite fullHeart;


    private int check = 0;

    private bool isJoker = false;

    public int hp = 3;

    private int nowCard = 0;
    bool checkCard = false; //перевірка на повтор карти

    private bool gameEnded = false;

    private Animator cardAnimation;
    private Animator jokerAnimation;


    void Start()
    {
        cardAnimation = randCard.GetComponent<Animator>();
        jokerAnimation = jokerCard.GetComponent<Animator>();

        firstDeck.onClick.AddListener(PutCard);
        secondDeck.onClick.AddListener(PutJoker);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (!gameEnded)
        {
            if(hp >= 3)
            {
                hp = 3;
            }
            if (hp == 3)
            {
                ChangeHpSprite(3);
            }
            else if (hp == 2)
            {
                ChangeHpSprite(2);
            }
            else if(hp == 1)
            {
                ChangeHpSprite(1);
            }
            else if(hp == 0)
            {
                ChangeHpSprite(0);
            }
        }

    }
    private void PutCard()
    {
        if (check == 0)
        {
            cardSound.Play();
            int chooseCard = Random.Range(0, cards.Length);
            randCard.sprite = cards[chooseCard];
            randCard.gameObject.SetActive(true);
            check++;
            nowCard = chooseCard;
        }
        else
        {
            if (isJoker == false) 
            {
                cardSound.Play();
                if (randCard.sprite == jokerSprite)
                {
                    hp--;
                    minusHpSound.Play();
                }
                randCard.gameObject.SetActive(false);
                previousCard.sprite = randCard.sprite;
                previousCard.gameObject.SetActive(true);

                int chooseCard = Random.Range(0, cards.Length);
                while (checkCard == false)
                {
                    if(chooseCard == nowCard)
                    {
                        chooseCard = Random.Range(0, cards.Length);
                    }
                    else
                    {
                        break;
                    }
                }
                randCard.sprite = cards[chooseCard];
                randCard.gameObject.SetActive(true);
                nowCard = chooseCard;
            }
            else if(isJoker == true)
            {
                cardSound.Play();
                previousCard.sprite = jokerCard.sprite;
                jokerCard.gameObject.SetActive(false);
                previousCard.gameObject.SetActive(true);

                int chooseCard = Random.Range(0, cards.Length);
                while (checkCard == false)
                {
                    if (chooseCard == nowCard)
                    {
                        chooseCard = Random.Range(0, cards.Length);
                    }
                    else
                    {
                        break;
                    }
                }
                randCard.sprite = cards[chooseCard];
                randCard.gameObject.SetActive(true);

                isJoker = false;
                nowCard = chooseCard;
            }

        }
        cardAnimation.Play("MoveCard");
    }
    private void PutJoker()
    {
        if(check != 0 && isJoker == false)
        {
            cardSound.Play();
            jokerCard.sprite = jokerSprite;
            jokerCard.gameObject.SetActive(true);
            previousCard.sprite = randCard.sprite;
            previousCard.gameObject.SetActive(true);
            randCard.gameObject.SetActive(false);

            isJoker = true;

            if (previousCard.sprite != jokerCard.sprite)
            {
                hp--;
                minusHpSound.Play();
            }
            else if(previousCard.sprite == jokerCard.sprite)
            {
                Score.Instance.AddScore();
                Timer.Instance.AddMinute();
                Money.Instance.AddMoney();
            }
        }
        jokerAnimation.Play("MoveJokerCard");
    }
    private void ChangeHpSprite(int count)
    {
        switch(count)
        {
            case 3:
                hp3.sprite = fullHeart;
                hp2.sprite = fullHeart;
                hp1.sprite = fullHeart;
                break;
            case 2:
                hp3.sprite = emptyHeart;
                hp2.sprite = fullHeart;
                hp1.sprite = fullHeart;
                break;
            case 1:
                hp2.sprite = emptyHeart;
                hp1.sprite = fullHeart;
                ScaleAnim anim = plusHeart.GetComponent<ScaleAnim>();
                anim.enabled = true;
                break;
            case 0:
                gameEnded = true;
                hp1.sprite=emptyHeart;
                Timer.Instance.EndGame();
                break;
        }
    }
}

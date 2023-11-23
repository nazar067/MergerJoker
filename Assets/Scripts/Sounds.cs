using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    public Button soundButton;
    public Button musicButton;

    public Sprite mus_on, mus_off;
    public Sprite sound_on, sound_off;

    public AudioSource musics;
    public AudioSource btnSound;
    public AudioSource cardSound;
    public AudioSource scoreSound;
    public AudioSource hpSound;
    public AudioSource buySound;
    public AudioSource minusHpSound;
    public AudioSource loseSound;

    public Slider volumeSlider;
    public Slider musicSlider;


    private int sound = 1;
    private int music = 1;
    void Start()
    {
        sound = PlayerPrefs.GetInt("sound", 1);
        music = PlayerPrefs.GetInt("music", 1);

        btnSound.volume = PlayerPrefs.GetFloat("volumeSound", 1);
        cardSound.volume = PlayerPrefs.GetFloat("volumeSound", 1);
        scoreSound.volume = PlayerPrefs.GetFloat("volumeSound", 1);
        hpSound.volume = PlayerPrefs.GetFloat("volumeSound", 1);
        buySound.volume = PlayerPrefs.GetFloat("volumeSound", 1);
        minusHpSound.volume = PlayerPrefs.GetFloat("volumeSound", 1);
        loseSound.volume = PlayerPrefs.GetFloat("volumeSound", 1);
        volumeSlider.value = PlayerPrefs.GetFloat("volumeSoundSlider", 1);
        musicSlider.value = PlayerPrefs.GetFloat("volumeMusicSoundSlider", 1);

        soundButton.onClick.AddListener(Sound);

        musicButton.onClick.AddListener(Music);

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
    }
    void ChangeVolume(float volume)
    {
        btnSound.volume = volume;
        cardSound.volume = volume;
        scoreSound.volume = volume;
        hpSound.volume = volume;
        buySound.volume = volume;
        minusHpSound.volume = volume;
        loseSound.volume = volume;
        PlayerPrefs.SetFloat("volumeSoundSlider", btnSound.volume);
        PlayerPrefs.SetFloat("volumeSound", btnSound.volume);
    }
    void ChangeMusicVolume(float volume)
    {
        musics.volume = volume;
        PlayerPrefs.SetFloat("volumeMusicSoundSlider", musics.volume);
    }
    private void Update()
    {
        if (sound == 1)
        {
            btnSound.mute = false;
            cardSound.mute = false;
            scoreSound.mute = false;
            hpSound.mute = false;
            buySound.mute = false;
            minusHpSound.mute = false;
            loseSound.mute = false;
            soundButton.GetComponent<Image>().sprite = sound_on;
        }
        if (sound == 0)
        {
            btnSound.mute = true;
            cardSound.mute = true;
            scoreSound.mute = true;
            hpSound.mute = true;
            buySound.mute = true;
            minusHpSound.mute = true;
            loseSound.mute = true;


            soundButton.GetComponent<Image>().sprite = sound_off;
        }
        if (music == 1)
        {
            musics.mute = false;

            musicButton.GetComponent<Image>().sprite = mus_on;
        }
        if (music == 0)
        {
            musics.mute = true;

            musicButton.GetComponent<Image>().sprite = mus_off;
        }
    }
    private void Sound()
    {
        if (sound == 1)
        {
            sound = 0;
            PlayerPrefs.SetInt("sound", sound);
        }
        else if (sound == 0)
        {
            sound = 1;
            PlayerPrefs.SetInt("sound", sound);
        }
    }
    private void Music()
    {
        if (music == 1)
        {
            music = 0;
            PlayerPrefs.SetInt("music", music);
        }
        else if (music == 0)
        {
            music = 1;
            PlayerPrefs.SetInt("music", music);
        }
    }


}

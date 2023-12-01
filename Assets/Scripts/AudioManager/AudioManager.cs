using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    [SerializeField] private AudioSource background_audioSource;
    [SerializeField] private AudioSource sfx_AudioSource;
    [SerializeField] private AudioClip backgroundSound;
    [SerializeField] private AudioClip gameoverSound;
    [SerializeField] private AudioClip gamewinSound;
    [SerializeField] private AudioClip gamePlaySound;
    [SerializeField] private AudioClip gamePauseSound;
    [SerializeField] private AudioClip buttonSound;
    // [SerializeField] private AudioClip gunfiresound;
    [SerializeField] private bool gameoverSoundPlayed;
    [SerializeField] private bool gamewinSoundPlayed;
    [SerializeField] private bool gameplaySoundPlayed;
    [SerializeField] private bool backgroundSoundPlayed;
    [SerializeField] private bool gamepusedSouundPlayed;
    [SerializeField] private bool buttonSoundPlayed;

    public static AudioManager Instance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        background_audioSource.clip = backgroundSound;
        background_audioSource.Play();
        CheckSetting();
    }

    public void CheckSetting()
    {
        sfx_AudioSource.mute = (PlayerPrefs.GetInt("Sound", 1) == 1) ? false : true;
        background_audioSource.mute = (PlayerPrefs.GetInt("Music", 1) == 1) ? false : true;

    }

    public void GameOverSound()
    {
        sfx_AudioSource.clip = gameoverSound;
        sfx_AudioSource.Play();
        gameoverSoundPlayed = true;
    }

    public void GameWinSound()
    {
        sfx_AudioSource.clip = gamewinSound;
        sfx_AudioSource.Play();
        gamewinSoundPlayed = true;
    }

    public void GamePlaySound()
    {
        sfx_AudioSource.clip = gamePlaySound;
        sfx_AudioSource.Play();
        gameplaySoundPlayed = true;
    }
    public void BackgroundSound()
    {
        sfx_AudioSource.clip = backgroundSound;
        sfx_AudioSource.Play();
        backgroundSoundPlayed = true;


    }
    public void StopMusic()
    {
        backgroundSoundPlayed = false;
        sfx_AudioSource.Stop();
    }
    public void PauseSound()
    {
        sfx_AudioSource.clip = gamePauseSound;
        sfx_AudioSource.Play();
        gamepusedSouundPlayed = true;
    }
    public void ButtonSound()
    {
        sfx_AudioSource.clip = buttonSound;
        sfx_AudioSource.Play();
        buttonSoundPlayed = true;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
           
            ButtonSound();
        }
        
    }

} 
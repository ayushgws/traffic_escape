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
    [SerializeField] private AudioSource sfn_AudioSource;
    [SerializeField] private AudioSource sfm_AudioSource;

    [SerializeField] private AudioClip backgroundSound;
    [SerializeField] private AudioClip collideSound;
    [SerializeField] private AudioClip gameoverSound;
    [SerializeField] private AudioClip gamewinSound;
    [SerializeField] private AudioClip Spritessound;
    [SerializeField] private AudioClip warningSound;
   // [SerializeField] private AudioClip gunfiresound;
   [SerializeField] private AudioClip brickDestroyed;

    [SerializeField] private bool gameoverSoundPlayed;
    [SerializeField] private bool gamewinSoundPlayed;
    [SerializeField] private bool Spritessound_sfn;
    [SerializeField] private bool Brick_sfm;

    public static AudioManager Instance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance)
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
        sfx_AudioSource.mute = (PlayerPrefs.GetInt("Sound",1)==1)?false:true;
        background_audioSource.mute = (PlayerPrefs.GetInt("Music", 1) == 1) ? false : true;

    }

    public void PlayCollideSound()
    {
        sfx_AudioSource.clip = collideSound;
        sfx_AudioSource.Play();
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
    public void spritessound()
    {
        sfn_AudioSource.clip = Spritessound;
        sfn_AudioSource.Play();
        Spritessound_sfn = true;

    }
    public void warningsound()
    {

        sfx_AudioSource.clip = warningSound;
        sfx_AudioSource.Play();
       
    }
    /*public void GunFire()
    {
        sfx_AudioSource.clip = gunfiresound;
        sfx_AudioSource.Play();
    }*/

    public void BrickDestroyedSound()
    {
        sfm_AudioSource.clip = brickDestroyed;
        sfm_AudioSource.Play();
        Brick_sfm = true;
    }
}

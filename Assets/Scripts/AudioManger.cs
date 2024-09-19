using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    [SerializeField] public bool isMusicOn = true;
    [Header("-----------Audio Sources-----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("-----------Audio Clips-----------")]
    [SerializeField] public AudioClip uiBackground;
    [SerializeField] public AudioClip buttonClick;
    [SerializeField] public AudioClip shoot;
    [SerializeField] public AudioClip monsterdie;
    [SerializeField] public AudioClip step;
    [SerializeField] public AudioClip jump;
    [SerializeField] public AudioClip introGame;

    private void Start()
    {
        musicSource.clip = uiBackground;
        if (isMusicOn)
        {
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public void InvertMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, float volumeScale)
    {
        sfxSource.PlayOneShot(clip, volumeScale);
    }
    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClick);
    }
}

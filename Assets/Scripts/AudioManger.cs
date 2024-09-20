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
    [SerializeField] public AudioClip monsterattack;
    [SerializeField] public AudioClip robot;
    [SerializeField] public AudioClip winEffect;
    [SerializeField] public AudioClip loseEffect;
    [SerializeField] public AudioClip dieSFX;
    [SerializeField] public AudioClip step;
    [SerializeField] public AudioClip jump;
    [SerializeField] public AudioClip introGame;
    [SerializeField] private GameObject player;

    private void Start()
    {
        musicSource.clip = uiBackground;
        if (isMusicOn)
        {
            musicSource.Play();
        }
        player = GameObject.Find("Player");
    }
    //private Vector3 previousPosition;
    void Update()
    {
        // if change the y position of player then play the step sound
        // if (player.transform.position.y != previousPosition.y)
        // {
        //     PlayStep();
        // }
        // previousPosition = player.transform.position;
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
    public void PlayShooting()
    {
        sfxSource.PlayOneShot(shoot);
    }
    public void PlayMonsterDie()
    {
        sfxSource.PlayOneShot(monsterdie);
    }
    public void PlayMonsterAttack()
    {
        sfxSource.PlayOneShot(monsterattack);
    }
    public void PlayRobot()
    {
        sfxSource.PlayOneShot(robot);
    }
    public void PlayWinEffect()
    {
        sfxSource.PlayOneShot(winEffect);
    }
    public void PlayLoseEffect()
    {
        sfxSource.PlayOneShot(loseEffect);
    }
    public void PlayDieSFX()
    {
        sfxSource.PlayOneShot(dieSFX);
    }
    public void PlayStep()
    {
        sfxSource.PlayOneShot(step);
    }
    public void PlayJump()
    {
        sfxSource.PlayOneShot(jump);
    }

}

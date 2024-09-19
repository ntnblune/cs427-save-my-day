using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    FirstPersonController player;
    [SerializeField] private AudioSource footstepSounds;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindObjectOfType<FirstPersonController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsWalking)
        {
            if (!footstepSounds.isPlaying)
            {
                footstepSounds.Play();
            }
        }
        else
        {
            footstepSounds.Pause();
        }
    }
}

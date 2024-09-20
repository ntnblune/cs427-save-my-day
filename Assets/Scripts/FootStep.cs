using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    GameObject footstep;
    FirstPersonController player;

    private void Start()
    {
        player = gameObject.GetComponent<FirstPersonController>();
        footstep = transform.Find("Footstep").gameObject;
        footstep.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(player.IsWalking);
        if (player.IsWalking)
        {
            footstep.SetActive(true);
        }
        else
        {
            footstep.SetActive(false);
        }
    }
}

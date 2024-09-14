using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public static Action inputShoot;
    public static Action inputReload;

    private KeyCode reloadKey = KeyCode.R;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            inputShoot?.Invoke();
        }
        if (Input.GetKeyDown(reloadKey))
        {
            inputReload?.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : Interactable
{
    protected override void Interact()
    {
        Debug.Log("Interact with " + gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        messageInteract = "Enemy";       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

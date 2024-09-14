using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDameable
{
    private float health = 100f;
    public void TakeDame(float dame)
    {
        health -= dame;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}


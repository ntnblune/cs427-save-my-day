using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour, IDameable
{
    [SerializeField] private float maxHealth = 3f;
    private float currentHealth;
    private HealthBar _healthBar;
    void Awake()
    {
        currentHealth = maxHealth;
//        _healthBar = GetComponentInChildren<HealthBar>();
//        _healthBar.SetHealth(currentHealth, maxHealth);
    }
    public void TakeDame(float dame)
    {
        currentHealth -= Random.Range(0.5f, 1.5f);
        if (currentHealth <= 0)
        {
            // Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else 
        {
            _healthBar.SetHealth(currentHealth, maxHealth);
            // Instantiate(_hitEffect, transform.position, Quaternion.identity);
        }
    }
}


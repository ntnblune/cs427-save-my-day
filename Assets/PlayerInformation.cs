using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private HealthBarMain _healthBar;
    private float currentHealth;
    public int currentPoint = 0;
    void Awake()
    {
        currentHealth = maxHealth;
        currentPoint = 0;
        _healthBar.SetHealth(currentHealth, maxHealth);
    }
    public void TakeDame(float dame)
    {
        currentHealth -= Random.Range(0.5f, 1.5f) * dame;
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

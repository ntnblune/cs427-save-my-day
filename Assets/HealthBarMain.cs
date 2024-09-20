using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarMain : MonoBehaviour
{
    Image _healthBar;
    void Awake()
    {
        // find child with name Blood
        _healthBar = transform.Find("Blood").GetComponent<Image>();
    }

    public void SetHealth(float maxHealth, float currentHealth)
    {
        _healthBar.fillAmount = currentHealth / maxHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarMonster : MonoBehaviour
{
    Image _healthBar;
    private Camera _camera;
    void Awake()
    {
        _camera = Camera.main;
        _healthBar = transform.Find("Blood").GetComponent<Image>();
    }

    public void SetHealth(float maxHealth, float currentHealth)
    {
        _healthBar.fillAmount = currentHealth / maxHealth;
    }
    void Update()
    {
        transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}

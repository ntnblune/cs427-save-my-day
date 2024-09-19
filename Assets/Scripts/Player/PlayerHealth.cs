using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float health;
    private float timer;
    public float maxHealth = 100;
    public float speed = 2f;

    public Image healthBar;
    public Image bloodScreen;

    float duration = 2.0f;
    float fadespeed = 1.5f;
    float durationTimer;
    private Camera cameraShake;

    private float lastTimeTookDamage;
    private float timeToNextTakeDamage = 2.0f;

    void Start()
    {
        health = maxHealth;
        // Image in the object name Blood
        healthBar = GameObject.Find("Blood").GetComponent<Image>();
        bloodScreen = GameObject.Find("DameEffect").GetComponent<Image>();
        //cameraShake = GameObject.Find("MainCamera").GetComponent<Camera>();
        bloodScreen.color = new Color(bloodScreen.color.r, bloodScreen.color.g, bloodScreen.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(10);
        }

        UpdateUI();
        // if health < 30 then always show blood screen
        if (health < 30)
        {
            bloodScreen.color = new Color(bloodScreen.color.r, bloodScreen.color.g, bloodScreen.color.b, 1);
        }

        if (bloodScreen.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float alpha = bloodScreen.color.a;
                alpha -= fadespeed * Time.deltaTime;
                bloodScreen.color = new Color(bloodScreen.color.r, bloodScreen.color.g, bloodScreen.color.b, alpha);
            }
        }




    }

    public void UpdateUI()
    {

        healthBar.fillAmount = 1 - health / maxHealth;

    }

    public void TakeDamage(float damage)
    {
        
        if (Time.time - lastTimeTookDamage < timeToNextTakeDamage)
        {
            return;
        }
        lastTimeTookDamage = Time.time;

        health -= damage;
        Debug.Log(health);
        if (health >= 30){
            durationTimer = 0;
            bloodScreen.color = new Color(bloodScreen.color.r, bloodScreen.color.g, bloodScreen.color.b, 1);
        }

        if (health <= 0)
        {
            //Die();
        }
    }
}

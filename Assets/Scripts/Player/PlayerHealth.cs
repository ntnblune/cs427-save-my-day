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

    public Image healScreen;

    float duration = 2.0f;
    float fadespeed = 1.5f;
    float durationTimer;
    private Camera cameraShake;

    private float lastTimeTookDamage;
    private float timeToNextTakeDamage = 2.0f;
    private AudioManger audioManager;

    private int numberOfLives = 3;
    private Image numberLivesImage;

    void Start()
    {
        health = maxHealth;
        // Image in the object name Blood
        healthBar = GameObject.Find("Blood").GetComponent<Image>();
        healScreen = GameObject.Find("HealEffect").GetComponent<Image>();
        bloodScreen = GameObject.Find("DameEffect").GetComponent<Image>();
        //cameraShake = GameObject.Find("MainCamera").GetComponent<Camera>();
        bloodScreen.color = new Color(bloodScreen.color.r, bloodScreen.color.g, bloodScreen.color.b, 0);
        healScreen.color = new Color(healScreen.color.r, healScreen.color.g, healScreen.color.b, 0);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
        numberLivesImage = GameObject.Find("Stars").GetComponent<Image>();

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

        if (healScreen.color.a > 0)
        {
            timer += Time.deltaTime;
            if (timer > duration)
            {
                float alpha = healScreen.color.a;
                alpha -= fadespeed * Time.deltaTime;
                healScreen.color = new Color(healScreen.color.r, healScreen.color.g, healScreen.color.b, alpha);
            }
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
        timeToNextTakeDamage = 2.0f;
        lastTimeTookDamage = Time.time;
        audioManager.PlayMonsterAttack();
        health -= damage;
        Debug.Log(health);
        if (health >= 30){
            durationTimer = 0;
            bloodScreen.color = new Color(bloodScreen.color.r, bloodScreen.color.g, bloodScreen.color.b, 1);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void redisplayLifes(){

        // change source image to display
        switch (numberOfLives)
        {
            case 3:
                numberLivesImage.sprite = Resources.Load<Sprite>("3-3");
                break;
            case 2:
                numberLivesImage.sprite = Resources.Load<Sprite>("2-3");
                break;
            case 1:
                numberLivesImage.sprite = Resources.Load<Sprite>("1-3");
                break;
            default:
                numberLivesImage.sprite = Resources.Load<Sprite>("0-3");
                break;
        }
    }
    private void Die()
    {
        if (numberOfLives > 0)
        {
            numberOfLives--;
            health = maxHealth;
            timeToNextTakeDamage = 6.0f;
            healScreen.color = new Color(healScreen.color.r, healScreen.color.g, healScreen.color.b, 1);
            redisplayLifes();
        }
        else
        {
            // Game Over
            Debug.Log("Game Over");
            //audioManager.PlayMonsterDie();
         //Destroy(gameObject);
        }

    }
}

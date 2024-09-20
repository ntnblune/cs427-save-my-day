using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentHealth;
    private float timer;
    public float maxHealth = 10;
    public float speed = 2f;
    HealthBarMain healthBarMain;
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

    private Transform playerTransform;

    void Start()
    {
        currentHealth = maxHealth;
        // Image in the object name Blood
        healthBarMain = GameObject.Find("HealthBarMain").GetComponent<HealthBarMain>();
        healScreen = GameObject.Find("HealEffect").GetComponent<Image>();
        bloodScreen = GameObject.Find("DameEffect").GetComponent<Image>();
        //cameraShake = GameObject.Find("MainCamera").GetComponent<Camera>();
        bloodScreen.color = new Color(bloodScreen.color.r, bloodScreen.color.g, bloodScreen.color.b, 0);
        healScreen.color = new Color(healScreen.color.r, healScreen.color.g, healScreen.color.b, 0);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
        numberLivesImage = GameObject.Find("Stars").GetComponent<Image>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(1);
        }

        // if currentHealth < 30 then always show blood screen
        if (currentHealth / maxHealth < 0.3)
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

    bool isDead()
    {
        // y corodinate of player is less than -100
        return currentHealth <= 0 || playerTransform.position.y < -100;
    }

    public void UpdateUI()
    {
        healthBarMain.SetHealth(currentHealth, maxHealth);
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
        currentHealth -= damage * Random.Range(0.8f, 1.2f);
        healthBarMain.SetHealth(maxHealth, currentHealth);
        if (currentHealth / maxHealth >= 0.3){
            durationTimer = 0;
            bloodScreen.color = new Color(bloodScreen.color.r, bloodScreen.color.g, bloodScreen.color.b, 1);
        }

        if (currentHealth <= 0)
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
            currentHealth = maxHealth;
            
            healthBarMain.SetHealth(maxHealth, currentHealth);
            timeToNextTakeDamage = 6.0f;
            healScreen.color = new Color(healScreen.color.r, healScreen.color.g, healScreen.color.b, 1);
            // spawn player at the start position
            playerTransform.position = new Vector3(33.68f, 0, 24.32f);
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

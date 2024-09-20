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

    public int numEnemies = 0;

    private SceneController sceneController;
    private GameObject scoreboardEndGame;

    void Awake()
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
        numberLivesImage = GameObject.Find("Canvas/Stars").GetComponent<Image>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        // count the number of object with tag Enemy
        numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Number of enemies: " + numEnemies);
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        scoreboardEndGame = GameObject.Find("CanvasGameEnd");

        scoreboardEndGame.SetActive(false);
    }

    void Start()
    {

    }

    public bool isGhost()
    {
        return numberOfLives <= 0;
    }

    void showScoreboardEndGame()
    {
        scoreboardEndGame.SetActive(true);
        // update image of scoreboard in CanvasEndGame/Stars

        switch (numberOfLives)
        {
            case 3:
                GameObject.Find("CanvasGameEnd/Stars").GetComponent<Image>().sprite  = Resources.Load<Sprite>("3-3");
                break;
            case 2:
                GameObject.Find("CanvasGameEnd/Stars").GetComponent<Image>().sprite  = Resources.Load<Sprite>("2-3");
                break;
            case 1:
               GameObject.Find("CanvasGameEnd/Stars").GetComponent<Image>().sprite  = Resources.Load<Sprite>("1-3");
                break;
            default:
                GameObject.Find("CanvasGameEnd/Stars").GetComponent<Image>().sprite  = Resources.Load<Sprite>("0-3");
                break;
        }

        GameObject.Find("CanvasGameEnd/Score").GetComponent<Text>().text = "Score: " + GameObject.Find("ScoreBoard/Text").GetComponent<Text>().text;
        // if press enter then load main menu
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sceneController.LoadMapSelect();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(3);
        }

        if (isWin() || isGameOver())
        {
            audioManager.StopMusic();
            audioManager.PlayLoseEffect();
            showScoreboardEndGame();
        }

        if (isDead())
        {
            Die();
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
        return currentHealth <= 0 || playerTransform.position.y > 100 || playerTransform.position.y < -100;
    }

    public void UpdateUI()
    {
        healthBarMain.SetHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (isGhost())
        {
            return;
        }
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
    public void updateNumEnemies()
    {
        // numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        numEnemies--;
        Debug.Log("Number of enemies: " + numEnemies);
    }
    void redisplayLifes(){

        // change source image to display
        Debug.Log("Number of lives change: " + numberOfLives);
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
    bool isWin()
    {
        return numEnemies <= 0;
    }

    bool isGameOver()
    {
        return numberOfLives <= 0;
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
            playerTransform.position = new Vector3(33.68f, 0, 24.32f);
            //audioManager.PlayMonsterDie();
         //Destroy(gameObject);
        }

    }
}

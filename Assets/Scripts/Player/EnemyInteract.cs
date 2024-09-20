using System.Collections;
using System.Collections.Generic;
using Ilumisoft.HealthSystem.UI;
using UnityEngine;

public class EnemyInteract : Interactable
{
    public float currentHealth;
    public float maxHealth = 5;
    private HealthBarMonster healthbar;

    [SerializeField] private GameObject player;

     private AudioManger audioManager;
     [SerializeField] private GameObject scorebar;
    public override void Interact()
    {
        TakeDamage(1);
        // make effect when player interact with enemy

    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage * Random.Range(0.5f, 1.5f);
        healthbar.SetHealth(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        messageInteract = "Enemy";   
        player = GameObject.Find("Player");
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
        scorebar = GameObject.Find("ScoreBoard/Text");
        healthbar = GetComponentInChildren<HealthBarMonster>();
        healthbar.SetHealth(maxHealth, currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // if touch player then take damage for player
        if (Vector3.Distance(player.transform.position, transform.position) < 1.5f)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(2);
        }
    }

    private void Die()
    {
        audioManager.PlayMonsterDie();
        if (scorebar != null)
        scorebar.GetComponent<Scorebar>().UpdateScore(10);
        Destroy(gameObject);
    }
}

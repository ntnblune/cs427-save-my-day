using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : Interactable
{
    public int health = 100;

    [SerializeField] private GameObject player;

     private AudioManger audioManager;
     [SerializeField] private GameObject scorebar;
    public override void Interact()
    {
        TakeDamage(10);
        // make effect when player interact with enemy

    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        messageInteract = "Enemy";   
        player = GameObject.Find("Player");
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
        scorebar = GameObject.Find("ScoreBoard/Text");
    }

    // Update is called once per frame
    void Update()
    {
        // if touch player then take damage for player
        if (Vector3.Distance(player.transform.position, transform.position) < 1.5f)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(20);
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

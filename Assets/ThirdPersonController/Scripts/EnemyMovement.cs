using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float moveSpeed = 0.01f;
    public float range = 10f;
    public float rotationSpeed = 5f;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if(Vector3.Distance(transform.position, player.position) <= range && Vector3.Distance(transform.position, player.position) > 0.5f)
        {
            // input action movement
            // freez rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.deltaTime);
            // dont make enemy jump 
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            // create animation move

        }

    }
}

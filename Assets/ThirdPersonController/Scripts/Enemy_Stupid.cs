using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stupid : MonoBehaviour
{
    public Transform target;
    public EnemyRefs enemyRefs;

    private float shootingDistance = 10f;
    private float pathDelay = 0.1f;
    private void Awake()
    {
        enemyRefs = GetComponent<EnemyRefs>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        shootingDistance = enemyRefs.navMeshAgent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Enemy_Stupid Update");
        if (target != null){
            bool inShootingRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;
            if (inShootingRange){
                LockAtTarget();
            }
            else {
                UpdatePath();
            }
            enemyRefs.animator.SetBool("Shooting", inShootingRange);
        }
        enemyRefs.animator.SetFloat("Speed", enemyRefs.navMeshAgent.velocity.magnitude);
    }
 
    private void LockAtTarget(){
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);

    }

    private void UpdatePath(){
        if (Time.time > pathDelay){
            pathDelay = Time.time + enemyRefs.pathDelay;
            enemyRefs.navMeshAgent.SetDestination(target.position);
        }

    }
}

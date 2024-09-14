using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRefs : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Animator animator;
    [Header("Enemy Stats")]
    public float pathDelay = 0.1f;
    private void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

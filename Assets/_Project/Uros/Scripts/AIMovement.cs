using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    NavMeshAgent navMeshAgent;
    [SerializeField]
    float radiusOutOfBattle = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            transform.LookAt(player.transform);
        navMeshAgent.radius =radiusOutOfBattle;
    }
}

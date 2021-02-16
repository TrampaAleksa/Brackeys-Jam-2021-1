using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float radiusOutOfBattle = 1.5f;

    [NonSerialized] public Ally ally;
    
    private void Awake()
    {
        player = player ==null? GameObject.FindWithTag("Player") : player;
    }

    void Update()
    {
        AllyNavMeshAgent.SetDestination(player.transform.position);
        if (AllyNavMeshAgent.remainingDistance <= AllyNavMeshAgent.stoppingDistance)
            transform.LookAt(player.transform);
        AllyNavMeshAgent.radius = radiusOutOfBattle;
    }

    private NavMeshAgent AllyNavMeshAgent => ally.navMeshAgent;
}

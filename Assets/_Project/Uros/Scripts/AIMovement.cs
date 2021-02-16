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
    private NavMeshAgent navMeshAgent;
    
    private void Awake()
    {
        player = player ==null? GameObject.FindWithTag("Player") : player;
    }
    private void Start()
    {
        navMeshAgent = ally == null ? GetComponent<NavMeshAgent>() : ally.navMeshAgent;
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            transform.LookAt(player.transform);
        navMeshAgent.radius = radiusOutOfBattle;
    }
}

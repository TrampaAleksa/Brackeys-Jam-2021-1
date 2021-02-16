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
        ally.navMeshAgent.SetDestination(player.transform.position);
        if (ally.navMeshAgent.remainingDistance <= ally.navMeshAgent.stoppingDistance)
            transform.LookAt(player.transform);
        ally.navMeshAgent.radius = radiusOutOfBattle;
    }
}

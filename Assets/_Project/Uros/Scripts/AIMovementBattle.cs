using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovementBattle : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] GameObject player;
    public bool isRetreating = false;
    [SerializeField] float radiusInBattle = 1f;
    GameObject lookAt;

    [NonSerialized] public Ally ally;

    private void Awake()
    {
        player = player ==null? GameObject.FindWithTag("Player") : player;
        target = player;
    }

    void Update()
    {
        if (!isRetreating)
        {
            ally.navMeshAgent.SetDestination(target.transform.position);
            lookAt = target;
        }
        else
        {
            ally.navMeshAgent.SetDestination(player.transform.position);
            lookAt = player;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isRetreating = true;
        }

        if (Input.GetMouseButtonDown(1))
            isRetreating = false;
        if (ally.navMeshAgent.remainingDistance <= ally.navMeshAgent.stoppingDistance)
            transform.LookAt(lookAt.transform);
        ally.navMeshAgent.radius = radiusInBattle;
    }


    public bool InAttackRange() => ally.navMeshAgent.remainingDistance < ally.navMeshAgent.stoppingDistance;
}
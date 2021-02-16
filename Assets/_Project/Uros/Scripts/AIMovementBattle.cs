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
    private NavMeshAgent navMeshAgent;

    [NonSerialized] public Ally ally;

    private void Awake()
    {
        player = player ==null? GameObject.FindWithTag("Player") : player;
        target = player;
    }

    private void Start()
    {
        navMeshAgent = ally == null ? GetComponent<NavMeshAgent>() : ally.navMeshAgent;
    }
    

    void Update()
    {
        if (!isRetreating)
        {
            navMeshAgent.SetDestination(target.transform.transform.position);
            lookAt = target;
        }
        else
        {
            navMeshAgent.SetDestination(player.transform.position);
            lookAt = player;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isRetreating = true;
        }

        if (Input.GetMouseButtonDown(1))
            isRetreating = false;
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            transform.LookAt(lookAt.transform);
        navMeshAgent.radius = radiusInBattle;
    }


    public bool InAttackRange() => navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance;
}
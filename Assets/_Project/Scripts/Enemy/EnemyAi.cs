using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAi : MonoBehaviour
{
    public float timeBetweenAttacks;
    
    private AllyList allyList;
    private MeleeAttack meleeAttack;
    private NavMeshAgent navMeshAgent;
    
    private bool attackInCooldown;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        meleeAttack = GetComponent<MeleeAttack>();
    }

    private void Start()
    {
        allyList = AllyList.Instance;
    }

    void Update()
    {
        // TryAttacking();
    }

    private void TryAttacking()
    {
        if (allyList.allies.Count != 0 && allyList.currentIndex < allyList.allies.Count)
            navMeshAgent.SetDestination(allyList.allies[AllyList.Instance.currentIndex].transform.transform.position);
        else return;

        var inAttackRange = navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance;
        if (!inAttackRange) return;

        if (attackInCooldown) return;

        attackInCooldown = true;

        if (allyList.allies.Count == 0)
        {
            print("Game over");
            return;
        }

        meleeAttack.LaunchAttack(allyList.allies[AllyList.Instance.currentIndex].transform);
        gameObject.AddComponent<TimedAction>().StartTimedAction(FinishAttack, timeBetweenAttacks);
    }

    private void FinishAttack()
    {
        attackInCooldown = false;
    }
}
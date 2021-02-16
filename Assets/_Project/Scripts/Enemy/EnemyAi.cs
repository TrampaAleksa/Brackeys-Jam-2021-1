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
    private Transform currentTarget;

    private Transform _transform;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        meleeAttack = GetComponent<MeleeAttack>();
        _transform = transform;
        AllyList.allyDiedEvent += TargetKilled;
    }

    private void Start()
    {
        allyList = AllyList.Instance;
        currentTarget = FirstAllyInList();
    }

    private Transform FirstAllyInList()
    {
        if (allyList.allies.Count == 0)
        {
            print("Game over");
            return transform;
        }
        
        if (allyList.allies.Count == 0) return transform;
        if (allyList.allies[0] == null) return transform;
        
        return allyList.allies[0].transform;
    }

    void Update()
    {
        TryAttacking();
    }

    private void TryAttacking()
    {
        navMeshAgent.SetDestination(currentTarget.position);
        if (currentTarget == _transform) return;

        var inAttackRange = navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance;
        if (!inAttackRange) return;

        if (attackInCooldown) return;

        attackInCooldown = true;

        if (allyList.allies.Count == 0)
        {
            print("Game over");
            return;
        }

        meleeAttack.LaunchAttack(currentTarget);
        
        gameObject.AddComponent<TimedAction>().StartTimedAction(FinishAttack, timeBetweenAttacks);
    }

    private void FinishAttack()
    {
        attackInCooldown = false;
    }

    private void TargetKilled()
    {
        currentTarget = FirstAllyInList();
    }
}
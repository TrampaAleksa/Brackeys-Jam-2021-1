using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAi : MonoBehaviour
{
    public float timeBetweenAttacks;

    private AllyList allyList;
    private Attack meleeAttack;
    private NavMeshAgent navMeshAgent;

    private bool attackInCooldown;
    private Transform currentTarget;

    private Transform _transform;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        meleeAttack = GetComponent<Attack>();
        _transform = transform;
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

        var inAttackRange = navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance && navMeshAgent.remainingDistance > 0.0005f;
        if (!inAttackRange) return;

        transform.LookAt(new Vector3(currentTarget.position.x, transform.position.y, currentTarget.position.z));
        
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

    public void TargetKilled()
    {
        currentTarget = FirstAllyInList();
    }
}
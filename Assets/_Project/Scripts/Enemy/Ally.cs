using System;
using UnityEngine;
using UnityEngine.AI;

public class Ally : MonoBehaviour
{
    [NonSerialized]public Attack attack;
    [NonSerialized]public Health health;
    [NonSerialized]public AttackHitDetector hitDetector;
    [NonSerialized]public AIMovementBattle aiMovementBattle;
    [NonSerialized]public AIMovement aiMovement;
    [NonSerialized]public NavMeshAgent navMeshAgent;

    private AllyAttackAi _allyAttackAi;

    private void Awake()
    {
        attack = GetComponentInChildren<Attack>();
        health = GetComponentInChildren<Health>();
        hitDetector = GetComponentInChildren<AttackHitDetector>();
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        aiMovementBattle = GetComponentInChildren<AIMovementBattle>();
        aiMovement = GetComponentInChildren<AIMovement>();

        _allyAttackAi = GetComponentInChildren<AllyAttackAi>();

        aiMovementBattle.ally = this;
        aiMovement.ally = this;
        _allyAttackAi.ally = this;
    }
}
using System;
using UnityEngine;
using UnityEngine.AI;

public class Ally : MonoBehaviour
{
    [NonSerialized]public Attack attack;
    [NonSerialized]public Health health;
    [NonSerialized]public AttackHitDetector hitDetector;
    [NonSerialized]public NavMeshAgent navMeshAgent;

    [NonSerialized]public AllyMovement movement;

    private AllyAttackAi _allyAttackAi;

    private void Awake()
    {
        attack = GetComponentInChildren<Attack>();
        health = GetComponentInChildren<Health>();
        hitDetector = GetComponentInChildren<AttackHitDetector>();
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        movement = GetComponentInChildren<AllyMovement>();
        _allyAttackAi = GetComponentInChildren<AllyAttackAi>();
        
        _allyAttackAi.ally = this;
        movement.ally = this;
    }
}
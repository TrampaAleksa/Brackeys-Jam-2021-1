using System;
using UnityEngine;

public class Ally : MonoBehaviour
{
    [NonSerialized]public Attack attack;
    [NonSerialized]public Health health;
    [NonSerialized]public AttackHitDetector hitDetector;
    [NonSerialized]public AIMovementBattle aiMovementBattle;
    [NonSerialized]public AIMovement aiMovement;

    private void Awake()
    {
        attack = GetComponent<Attack>();
        health = GetComponent<Health>();
        hitDetector = GetComponent<AttackHitDetector>();
        aiMovementBattle = GetComponent<AIMovementBattle>();
        aiMovement = GetComponent<AIMovement>();
    }
}
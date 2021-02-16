using System;
using UnityEngine;

public class AllyAttackAi : MonoBehaviour
{
    public float timeBetweenAttacks;
    [NonSerialized] public Ally ally;
    private AIMovementBattle _aiMovementBattle;
    private Attack _attack;
    private bool attackInCooldown;

    private void Start()
    {
        _aiMovementBattle = ally == null ? GetComponent<AIMovementBattle>() : ally.aiMovementBattle;
        _attack = ally == null ? GetComponent<Attack>() : ally.attack;
    }

    private void Update()
    {
        if (!_aiMovementBattle.enabled) return;
        
        TryAttacking();
    }

    private void TryAttacking()
    {
        if (!_aiMovementBattle.InAttackRange()) return;
        
        if (attackInCooldown) return;

        attackInCooldown = true;
        _attack.LaunchAttack(_aiMovementBattle.target.transform);
        gameObject.AddComponent<TimedAction>().StartTimedAction(FinishAttack, timeBetweenAttacks);
    }

    private void FinishAttack()
    {
        attackInCooldown = false;
    }
    
}
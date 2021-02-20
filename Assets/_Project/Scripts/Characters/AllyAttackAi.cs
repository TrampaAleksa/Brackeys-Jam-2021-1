using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AllyAttackAi : MonoBehaviour
{
    public float timeBetweenAttacks;

    public float attackTimeOffset;
    
    [NonSerialized] public Ally ally;
    private bool attackInCooldown;

    private void Update()
    {
        if (ally.movement.state != AllyMovementState.InBattle) return;
        
        TryAttacking();
    }

    private void TryAttacking()
    {
        if (!ally.movement.InAttackRange) return;
        
        if (attackInCooldown) return;

        attackInCooldown = true;
        ally.attack.LaunchAttack(ally.movement.target.transform);
        gameObject.AddComponent<TimedAction>().StartTimedAction(FinishAttack, timeBetweenAttacks + Random.Range(-attackTimeOffset, attackTimeOffset));
    }

    private void FinishAttack()
    {
        attackInCooldown = false;
    }
    
}
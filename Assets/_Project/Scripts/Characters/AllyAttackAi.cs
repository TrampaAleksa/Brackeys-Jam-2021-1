using System;
using UnityEngine;

public class AllyAttackAi : MonoBehaviour
{
    public float timeBetweenAttacks;
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
        gameObject.AddComponent<TimedAction>().StartTimedAction(FinishAttack, timeBetweenAttacks);
    }

    private void FinishAttack()
    {
        attackInCooldown = false;
    }
    
}
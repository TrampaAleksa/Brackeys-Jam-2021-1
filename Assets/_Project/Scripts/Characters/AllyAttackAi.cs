using System;
using UnityEngine;

public class AllyAttackAi : MonoBehaviour
{
    public float timeBetweenAttacks;
    
    [NonSerialized] public Ally ally;

    private bool attackInCooldown;


    private void Update()
    {
        if (!ally.aiMovementBattle.enabled) return;
        
        TryAttacking();
    }

    private void TryAttacking()
    {
        if (!ally.aiMovementBattle.InAttackRange()) return;
        
        if (attackInCooldown) return;

        attackInCooldown = true;
        ally.attack.LaunchAttack(ally.aiMovementBattle.target.transform);
        gameObject.AddComponent<TimedAction>().StartTimedAction(FinishAttack, timeBetweenAttacks);
    }

    private void FinishAttack()
    {
        attackInCooldown = false;
    }
}
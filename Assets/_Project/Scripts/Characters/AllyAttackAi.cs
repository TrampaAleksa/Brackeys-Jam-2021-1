using UnityEngine;

public class AllyAttackAi : MonoBehaviour
{

    public float timeBetweenAttacks;
    
    private AIMovementBattle aiMovementBattle;
    private Attack _attack;

    private bool attackInCooldown;

    private void Awake()
    {
        _attack = GetComponent<Attack>();
        aiMovementBattle = GetComponent<AIMovementBattle>();
    }

    private void Update()
    {
        if (!aiMovementBattle.enabled) return;
        
        TryAttacking();
    }

    private void TryAttacking()
    {
        var inAttackRange = aiMovementBattle.navMeshAgent.remainingDistance < aiMovementBattle.navMeshAgent.stoppingDistance;
        if (!inAttackRange) return;
        
        if (attackInCooldown) return;

        attackInCooldown = true;
        _attack.LaunchAttack(aiMovementBattle.target.transform);
        gameObject.AddComponent<TimedAction>().StartTimedAction(FinishAttack, timeBetweenAttacks);
    }

    private void FinishAttack()
    {
        attackInCooldown = false;
    }
}
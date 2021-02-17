using System;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] GameObject player;
    public AllyMovementState state;
    
    [SerializeField] float radiusInBattle = 1f;
    [SerializeField] float radiusOutOfBattle = 1.5f;
    [SerializeField] float retreatRadius = 1.5f;

    [NonSerialized] public Ally ally;
    
    private void Awake()
    {
        player = player ==null? GameObject.FindWithTag("Player") : player;
        target = player;
    }
    
    void Update()
    {
        switch (state)
        {
            case AllyMovementState.Disabled:
                break;
            case AllyMovementState.OutOfBattle:
                OutOfCombatMovement();
                break;
            case AllyMovementState.InBattle:
                InBattleMovement();
                break;
            case AllyMovementState.Retreating:
                RetreatMovement();
                break;
        }
    }

    private void RetreatMovement()
    {
        ally.navMeshAgent.SetDestination(player.transform.position);
        ally.navMeshAgent.radius = retreatRadius;
        
        if (InAttackRange)
            transform.LookAt(player.transform);
    }

    private void InBattleMovement()
    {
        ally.navMeshAgent.SetDestination(target.transform.position);
        ally.navMeshAgent.radius = radiusInBattle;
        
        if (InAttackRange)
            transform.LookAt(target.transform);
    }

    private void OutOfCombatMovement()
    {
        ally.navMeshAgent.SetDestination(player.transform.position);
        ally.navMeshAgent.radius = radiusOutOfBattle;
        
        if (InAttackRange)
            transform.LookAt(player.transform);
    }
    
    public bool InAttackRange => ally.navMeshAgent.remainingDistance < ally.navMeshAgent.stoppingDistance && ally.navMeshAgent.remainingDistance > 0.005f;

}

public enum AllyMovementState
{
    OutOfBattle,
    InBattle,
    Retreating,
    Disabled
}
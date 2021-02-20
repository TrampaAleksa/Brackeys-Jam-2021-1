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
        CalculatePath(player.transform);
        ally.navMeshAgent.stoppingDistance = retreatRadius;
        ally.navMeshAgent.radius = 1f;
        
        if (InAttackRange)
            transform.LookAt(player.transform);
    }

    private void InBattleMovement()
    {
        CalculatePath(target.transform);
        ally.navMeshAgent.stoppingDistance = radiusInBattle;
        ally.navMeshAgent.radius = 1f;

        
        if (InAttackRange)
            transform.LookAt(target.transform);
    }

    private void OutOfCombatMovement()
    {
        CalculatePath(player.transform);
        ally.navMeshAgent.stoppingDistance = radiusOutOfBattle;
        ally.navMeshAgent.radius = 1.5f;
        
        if (InAttackRange)
            transform.LookAt(player.transform);
    }

    private int _recalculateCounter;
    private void CalculatePath(Transform destination)
    {
        if (_recalculateCounter% 5 == 0)
        {
            ally.navMeshAgent.SetDestination(destination.position);
            _recalculateCounter = 0;
        }
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
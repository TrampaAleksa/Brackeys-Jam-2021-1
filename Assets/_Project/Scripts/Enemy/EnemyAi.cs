using UnityEngine;


public class EnemyAi : MonoBehaviour
{
    private MeleeAttack meleeAttack;
    public AttackHitDetector target;

    private void Awake()
    {
        meleeAttack = GetComponent<MeleeAttack>();
    }

    [ContextMenu("Attack Closest Target")]
    private void AttackClosestTarget()
    {
        meleeAttack.LaunchAttack(target.transform);
    }


}
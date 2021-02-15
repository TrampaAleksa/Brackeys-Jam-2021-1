using UnityEngine;

public class MeleeAttackTester : MeleeAttack
{
    public AttackHitDetector target;

    [ContextMenu("Attack the target")]
    public void TestAttack()
    {
        LaunchAttack(target.transform);
    }
}
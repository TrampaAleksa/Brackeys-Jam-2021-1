using UnityEngine;

public class ProjectileAttackTester : ProjectileAttack
{
    public Transform target;

    [ContextMenu("Launch projectile attack")]
    public void TestAttack()
    {
        LaunchAttack(target);
    }
}
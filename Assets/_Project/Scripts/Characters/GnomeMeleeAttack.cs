using UnityEngine;

public class GnomeMeleeAttack : Attack
{
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching small melee attack!");
        target.GetComponentInChildren<AttackHitDetector>().HitByAttack(type, baseDamage);
    }
}
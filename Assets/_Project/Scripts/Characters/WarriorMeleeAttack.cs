using UnityEngine;

public class WarriorMeleeAttack : Attack
{
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching melee attack!");
        target.GetComponentInChildren<AttackHitDetector>().HitByAttack(type, baseDamage);
    }
}
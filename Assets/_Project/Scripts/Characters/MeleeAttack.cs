using System;
using UnityEngine;

public class MeleeAttack : Attack
{
    public override void LaunchAttack(Transform target)
    {
            base.LaunchAttack(target);
            print("Launching melee attack!");
            target.GetComponent<AttackHitDetector>().HitByAttack(type, baseDamage);
    }
}
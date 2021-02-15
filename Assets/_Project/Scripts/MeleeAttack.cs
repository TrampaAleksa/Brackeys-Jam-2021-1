using System;
using UnityEngine;

public class MeleeAttack : Attack
{
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        if (target.CompareTag("Player") || target.CompareTag("Character"))
        {
            print("Launching melee attack!");
            target.GetComponent<AttackHitDetector>().HitByAttack(type, baseDamage);
        }
    }
}
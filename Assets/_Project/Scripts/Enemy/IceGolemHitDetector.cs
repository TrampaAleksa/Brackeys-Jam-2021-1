using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGolemHitDetector : AttackHitDetector
{
    private float damageReduction = 0.2f;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public override void HitByAttack(AttackType attackType, float baseAttackDamage)
    {
        var totalDamageTaken = baseAttackDamage;

        if (attackType == AttackType.Ice)
            totalDamageTaken *= damageReduction;
        
        _health.TakeDamage(totalDamageTaken);
        print("Ice goldem took: " + totalDamageTaken +  " damage");
    }
}

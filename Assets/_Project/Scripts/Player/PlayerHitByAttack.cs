using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitByAttack : AttackHitDetector
{
    [SerializeField]private Health playerHealth;

    private void Awake()
    {
        playerHealth = playerHealth == null? GetComponent<Health>() : playerHealth;
    }

    public override void HitByAttack(AttackType attackType, float baseAttackDamage)
    {
        base.HitByAttack(attackType, baseAttackDamage);
        playerHealth.TakeDamage(baseAttackDamage);
        print("The player was hit by an attack and took : " +  baseAttackDamage + " damage");

        if (playerHealth.currentHealth <= 0001f)
        {
            AllyList.Instance.AllyDied(playerHealth.transform.parent.GetComponent<Ally>());
        }
    }
}

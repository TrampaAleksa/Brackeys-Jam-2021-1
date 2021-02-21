using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Utility;
using UnityEngine;

public class IceGolemHitDetector : AttackHitDetector
{
    [SerializeField] GameObject manaProjectile;
    [SerializeField] GameObject[] collliders;

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

        if (_health.currentHealth <= 0.001f)
        {
            AllyList.Instance.ExitAllyCombat();
            TriggerBattleCollider.canSpawn = true;
            DestroyColliders();
            Instantiate(manaProjectile, transform.position, Quaternion.identity);
            AudioHolder.Instance.earthGolemDeath.Play();
            Destroy(gameObject);
        }
    }
    private void DestroyColliders()
    {
        for(int i =0; i < collliders.Length; i++)
        {
            Destroy(collliders[i]);
        }
    }
}
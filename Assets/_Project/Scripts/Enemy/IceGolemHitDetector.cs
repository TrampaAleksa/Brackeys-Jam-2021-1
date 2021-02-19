using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGolemHitDetector : AttackHitDetector
{
    [SerializeField] GameObject manaProjectile;
    [SerializeField] GameObject emptyGameObject;

    GameObject manaObj;
    GameObject emptyObj;
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
            spawnMana();           
            Destroy(gameObject);
        }
    }
    void spawnMana()
    {
        emptyObj = Instantiate(emptyGameObject, transform.position, Quaternion.identity);
        manaObj = Instantiate(manaProjectile, transform.position, Quaternion.identity);
        manaObj.transform.parent = emptyObj.transform;
    }
}
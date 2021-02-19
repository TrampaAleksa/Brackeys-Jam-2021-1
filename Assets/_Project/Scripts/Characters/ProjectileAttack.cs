using System;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileAttack : Attack
{
    public Projectile projectileObj;
    public float projectileSpeed;
    private Transform _attackerTransform;

    private void Awake()
    {
        _attackerTransform = transform;
    }

    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        
        print("Launching a projectile!");
        Instantiate(projectileObj, _attackerTransform.position, _attackerTransform.rotation).ChaseTarget(target, projectileSpeed, type, baseDamage);
        AudioHolder.Instance.PlayMageSpellSound();
    }
}
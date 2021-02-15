using System;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileAttack : Attack
{
    public Projectile projectileObj;
    public float projectileSpeed;
    
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        
        print("Launching a projectile!");
        Instantiate(projectileObj, transform).ChaseTarget(target, projectileSpeed, type, baseDamage);
    }
}
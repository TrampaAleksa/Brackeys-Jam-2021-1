using System;
using UnityEngine;

public class GnomeSpawnAttack : Attack
{
    public Ally gnomeAttacker;
    public int gnomeLimit = 5;

    private Transform _gnomeTransform;
    private int _numberOfGnomes;
    private void Awake()
    {
        _gnomeTransform = transform;
    }

    public override void LaunchAttack(Transform target)
    {
        if (_numberOfGnomes > gnomeLimit) return;

        base.LaunchAttack(target);
        print("Launching melee attack!");
        
        var gnomeAttackedSpawned = Instantiate(gnomeAttacker, _gnomeTransform.position + gnomeAttacker.transform.position, _gnomeTransform.rotation);
        gnomeAttackedSpawned.movement.target = target.gameObject;
        gnomeAttackedSpawned.movement.state = AllyMovementState.InBattle;

        _numberOfGnomes++;
    }
}
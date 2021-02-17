using UnityEngine;

public class GnomeSpawnAttack : Attack
{
    public Ally gnomeAttacker;
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching melee attack!");


        var gnomeAttackedSpawned = Instantiate(gnomeAttacker, transform);
        gnomeAttackedSpawned.movement.target = target.gameObject;
        gnomeAttackedSpawned.movement.state = AllyMovementState.InBattle;
    }
}
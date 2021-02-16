using UnityEngine;

public class IceGolemSpikeAttack : Attack
{
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching melee attack!");
        target.GetComponent<Ally>().hitDetector.HitByAttack(type, baseDamage);
    }
}
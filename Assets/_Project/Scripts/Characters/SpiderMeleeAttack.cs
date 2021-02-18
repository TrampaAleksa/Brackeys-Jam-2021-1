using UnityEngine;

public class SpiderMeleeAttack : Attack
{
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching spider melee attack!");
        target.GetComponent<Ally>().hitDetector.HitByAttack(type, baseDamage);
    }
}
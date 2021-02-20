using UnityEngine;

public class SpiderMeleeAttack : Attack
{

    private int _numberForSound;
    
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching spider melee attack!");
        target.GetComponent<Ally>().hitDetector.HitByAttack(type, baseDamage);

        _numberForSound = (_numberForSound+1) % 5;
        if (_numberForSound == 0) AudioHolder.Instance.spiderAttack.Play();
    }
}
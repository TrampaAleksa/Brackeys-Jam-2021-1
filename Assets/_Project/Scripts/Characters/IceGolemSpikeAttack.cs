using UnityEngine;

public class IceGolemSpikeAttack : Attack
{
    public GameObject spikeObj;
    public int numberOfSpikes;
    public float rangeBetweenSpikes;
    
    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching spike attack!");

        Instantiate(spikeObj, target.position, transform.rotation);
    }
}
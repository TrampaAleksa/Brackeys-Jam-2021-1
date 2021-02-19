using System;
using UnityEngine;

public class IceGolemSpikeAttack : Attack
{
    public GameObject spikeObj;
    public int numberOfSpikes;
    public float rangeBetweenSpikes;
    private Transform _golemTransform;

    private void Awake()
    {
        _golemTransform = transform;
    }

    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching spike attack!");

        for (int i = 0; i < numberOfSpikes; i++)
        {
            var currentSpawnPosition = _golemTransform.forward * (3f * (i+1)) + _golemTransform.position + Vector3.down*0.6f;
            Instantiate(spikeObj, currentSpawnPosition, _golemTransform.rotation);
            AudioHolder.Instance.iceGolemAttack.Play();
        }
    }
}
using System;
using UnityEngine;

public class ReaperCleaveAttack : Attack
{
    public GameObject cleaveConeObj;
    private Transform _reaperTransform;

    private void Awake()
    {
        _reaperTransform = transform;
    }

    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching reap attack!");

        Instantiate(cleaveConeObj, _reaperTransform.position, _reaperTransform.rotation);
    }
}
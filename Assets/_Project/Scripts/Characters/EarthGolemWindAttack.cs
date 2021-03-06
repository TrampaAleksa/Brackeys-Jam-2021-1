﻿using System;
using UnityEngine;

public class EarthGolemWindAttack : Attack
{
    public GameObject windObj;
    public float intervalOfDamage;
    
    private TimedAction _timedAction;
    private AllyList _allyList;
    private void Awake()
    {
        _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
    }

    private void Start()
    {
        _allyList = AllyList.Instance;
    }

    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching spike attack!");

        Instantiate(windObj, transform);
        AudioHolder.Instance.tornadoSounds.Play();
        _timedAction.StartTimedAction(DamageAllAllies, intervalOfDamage);
    }

    private void DamageAllAllies()
    {
        for (var index = 0; index < _allyList.allies.Count; index++)
        {
            var ally = _allyList.allies[index];
            ally.hitDetector.HitByAttack(type, baseDamage);
        }

        _timedAction.StartTimedAction(DamageAllAllies, intervalOfDamage);
    }
    
    
}
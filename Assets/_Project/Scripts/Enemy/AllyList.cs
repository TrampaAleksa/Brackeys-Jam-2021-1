﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class AllyList : MonoBehaviour
{
    public static AllyList Instance;
    public static Action allyDiedEvent;
    
    public List<Ally> allies;
    private GameObject _player;

    private void Awake()
    {
        if (allies == null) allies = new List<Ally>();
        
        Instance = this;
        _player = GameObject.FindWithTag("Player");
    }

    public void AllyRaised(Ally toAdd)
    {
        allies.Add(toAdd);
    }

    public void AllyDied(Ally ally)
    {
        allies.Remove(ally);
        allyDiedEvent?.Invoke();
        Destroy(ally.gameObject);
    }

    public List<Ally> GetAlliesOfType(AttackType attackType)
    {
        List<Ally> alliesOfType = new List<Ally>();
        foreach (var ally in allies)
        {
            if (ally.attack.type == attackType)
            {
                alliesOfType.Add(ally);
            }
        }

        return alliesOfType;
    }

    public void TriggerAllyCombat(Transform boss)
    {
        for (int i = 0; i < allies.Count; i++)
        {
            allies[i].movement.target = boss.gameObject;
            allies[i].movement.state = AllyMovementState.InBattle;
        }
        
        allyDiedEvent += boss.GetComponentInChildren<EnemyAi>().TargetKilled;
        boss.GetComponentInChildren<EnemyAi>().enabled = true;
    }

    public void ExitAllyCombat()
    {
        allyDiedEvent = null;

        for (int i = 0; i < allies.Count; i++)
        {
            allies[i].movement.target = _player.gameObject;
            allies[i].movement.state = AllyMovementState.OutOfBattle;
        }
    }
}
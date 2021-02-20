using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllyList : MonoBehaviour
{
    public static AllyList Instance;
    public static Action allyDiedEvent;
    public static Action combatEndedEvent;
    
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
        boss.GetComponent<Health>().died += ProjectileHolder.Instance.BossDiedEvent;
        
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
        combatEndedEvent?.Invoke();
        AudioHolder.Instance.TurnOffBossMusic();

        for (int i = 0; i < allies.Count; i++)
        {
            allies[i].movement.target = _player.gameObject;
            allies[i].movement.state = AllyMovementState.OutOfBattle;
        }
    }

    public void SortByTypes(AttackType bossType)
    {
        switch (bossType)
        {
            case AttackType.Ice: SetWeights(4, 3, 1, 2);
                break;
            case AttackType.Spider: SetWeights(2, 4, 3, 1);
                break;
            case AttackType.Wind: SetWeights(4, 3, 1, 2);
                break;
            case AttackType.Reaper: SetWeights(1, 3, 1, 2);
                break;
        }
        
        allies = allies.OrderBy((ally) => ally.weight).ToList();
    }

    private void SetWeights(int fireWeight, int iceWeight, int warriorWeight, int gnomeWeight)
    {
        foreach (var ally in allies)
        {
            switch (ally.attack.type)
            {
                case AttackType.Fire:
                    ally.weight = fireWeight;
                    break;
                case AttackType.Ice:
                    ally.weight = iceWeight;
                    break;
                case AttackType.Warrior:
                    ally.weight = warriorWeight;
                    break;
                case AttackType.Gnome:
                    ally.weight = gnomeWeight;
                    break;
            }
        }
    }
}
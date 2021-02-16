using System.Collections.Generic;
using UnityEngine;

public class AllyList : MonoBehaviour
{
    public static AllyList Instance;
    public List<Ally> allies;

    private void Awake()
    {
        Instance = this;
    }

    public void AllyRaised(Ally toAdd)
    {
        allies.Add(toAdd);
    }

    public void AllyDied(Ally ally)
    {
        allies.Remove(ally);
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
            allies[i].aiMovementBattle.target = boss.gameObject;
            allies[i].aiMovementBattle.enabled = true;
            allies[i].aiMovement.enabled = false;
        }

    }
}
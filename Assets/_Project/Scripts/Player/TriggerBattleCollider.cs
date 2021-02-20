using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattleCollider : MonoBehaviour
{
    public Transform boss;
    public AttackType bossType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {       
            AllyList.Instance.TriggerAllyCombat(boss);
            other.GetComponentInChildren<Heal>().inBatle = true;
            PlayBossSounds();
        }
    }

    private void PlayBossSounds()
    {
        switch (bossType)
        {
            case AttackType.Reaper:
                AudioHolder.Instance.battleStart.PlayDelayed(0.3f);
                AudioHolder.Instance.reaperLaughter.Play();
                AudioHolder.Instance.PlayBossFight(1);
                break;
            case AttackType.Ice:
                AudioHolder.Instance.battleStart.PlayDelayed(0.3f);
                AudioHolder.Instance.golemLaugh.Play();
                AudioHolder.Instance.PlayBossFight(0);
                break;
            case AttackType.Wind:
                AudioHolder.Instance.battleStart.PlayDelayed(0.3f);
                AudioHolder.Instance.golemLaugh.Play();
                AudioHolder.Instance.PlayBossFight(2);
                break;
            default: print("no boss type set, no sounds will be played");
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}

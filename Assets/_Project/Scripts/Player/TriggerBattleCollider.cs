using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattleCollider : MonoBehaviour
{
    public Transform boss;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {       
            AllyList.Instance.TriggerAllyCombat(boss);
            other.GetComponentInChildren<Heal>().inBatle = true;
            AudioHolder.Instance.battleStart.PlayDelayed(0.3f);
            AudioHolder.Instance.golemLaugh.Play();
            AudioHolder.Instance.PlayBossFight();
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

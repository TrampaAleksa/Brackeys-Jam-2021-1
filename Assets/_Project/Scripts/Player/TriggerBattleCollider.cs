using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattleCollider : MonoBehaviour
{
    bool inBattle = false;
    private List<Ally> _allies;
    public Transform boss;

    private void Start()
    {
        _allies = AllyList.Instance.allies;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {       
            inBattle = !inBattle;
            other.GetComponent<RetreatAlly>().enabled = inBattle;
            for (int i = 0; i < _allies.Count; i++)
            {
                _allies[i].aiMovementBattle.target = boss.gameObject;
                _allies[i].aiMovementBattle.enabled = inBattle;
                _allies[i].aiMovement.enabled = !inBattle;
            }
            
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

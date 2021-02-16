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
            other.GetComponent<RetreatAlly>().enabled = true;
            AllyList.Instance.TriggerAllyCombat(boss);
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

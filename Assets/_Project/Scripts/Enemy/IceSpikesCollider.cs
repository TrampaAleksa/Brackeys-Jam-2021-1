using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikesCollider : MonoBehaviour
{
    public AttackType type;
    public float baseAttackDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            other.GetComponent<Ally>().hitDetector.HitByAttack(type, baseAttackDamage);
        }
        /*
        if (other.CompareTag("Player"))
        {
            other.GetComponent<AttackHitDetector>().HitByAttack(type, baseAttackDamage);
        }
        */
    }
}

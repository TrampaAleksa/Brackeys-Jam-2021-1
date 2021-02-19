using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAllies : MonoBehaviour
{
    [SerializeField] float healingAmount = 5;

    Health health;
    void Start()
    {
        health = GetComponent<Ally>().health;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HealingZone"))
            health.Heal(healingAmount * Time.deltaTime);
    }
}

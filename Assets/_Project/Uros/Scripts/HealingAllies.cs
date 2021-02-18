using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAllies : MonoBehaviour
{
    [SerializeField] float healingAmount = 5;

    Health health;
    bool healingOn = false;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Ally>().health;
    }

    // Update is called once per frame
    void Update()
    {
        if (healingOn)
        {
            if (health.currentHealth < health.maxHealth)
            {
                health.Heal(healingAmount * Time.deltaTime);

            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealingZone"))
        {
            healingOn = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HealingZone"))
        {
            print("izasao");
            healingOn = false;
        }
    }
}

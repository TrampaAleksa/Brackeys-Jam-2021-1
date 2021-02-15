using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0 )
        {
            currentHealth = 0;
            print(gameObject.name + " Died!");
        }
    }

    public virtual void Heal(float healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth >= maxHealth) currentHealth = maxHealth;
    }
}


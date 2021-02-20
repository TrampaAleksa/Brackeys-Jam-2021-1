using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public Action healthChanged;
    public Action<Health> died;

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0 )
        {
            currentHealth = 0;
            print(gameObject.name + " Died!");
            died?.Invoke(this);
            return;
        }
        
        healthChanged?.Invoke();
    }
    
    public virtual void Heal(float healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth >= maxHealth) currentHealth = maxHealth;
        healthChanged?.Invoke();

    }
}


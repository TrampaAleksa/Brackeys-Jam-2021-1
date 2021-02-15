using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public virtual void TakeDamage(float damageAmount)
    {
        
    }

    public virtual void Heal(float healAmount)
    {
        
    }
}


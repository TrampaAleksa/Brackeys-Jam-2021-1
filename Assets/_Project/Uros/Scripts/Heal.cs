using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Heal : MonoBehaviour
{
    [SerializeField] float timeHealIsOn = 7f;
    [SerializeField] float cooldown = 3f;
    [NonSerialized] public bool inBatle = false;
    [NonSerialized] public bool healingIsActive = false;
    public static bool heal = false;
        
    ManaPool manaPool;
    float elapsedSeconds;
    float elapsedSecondsForCooldown;
    bool inCooldown = false;
    SphereCollider sphereCollider;

    void Start()
    {
        manaPool = ManaPool.Instance;
        sphereCollider = GetComponentInChildren<SphereCollider>();
    }
    void Update()
    {
       
        if (inCooldown)
        {
            elapsedSecondsForCooldown += Time.deltaTime;
            if (elapsedSecondsForCooldown >= cooldown)
            {
                inCooldown = false;
                elapsedSecondsForCooldown = 0;
            }
        }
        if (healingIsActive)
        {
            if (elapsedSeconds < timeHealIsOn)
            {
                print(elapsedSeconds);
                elapsedSeconds += Time.deltaTime;
            }
            else
            {
                elapsedSeconds = 0;
                healingIsActive = false;
                inCooldown = true;
                sphereCollider.enabled = false;

            }
        }
        if (Input.GetAxis("Jump") == 0) return;
        if (manaPool.remainingMana < manaPool.healCost) return;
        if (inCooldown) return;
        if (healingIsActive) return;
        if (!inBatle) return;
         healingIsActive = true;
         sphereCollider.enabled = true;       
    }
}

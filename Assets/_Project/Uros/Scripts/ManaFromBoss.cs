using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaFromBoss : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;
    Transform projectile;
    [SerializeField] float speedOfProjectile;
    [SerializeField] float ammountOfMana;
    ManaPool manaPool;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        projectile = transform;
    }

    private void Start()
    {
        manaPool = ManaPool.Instance;
    }

    void Update()
    {
        
        projectile.LookAt(playerTransform);
        projectile.position += projectile.forward * (speedOfProjectile * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manaPool.AddMana(ammountOfMana);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaFromBoss : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;
    Transform projectile;
    [SerializeField] float speedOfProjectile;
    [SerializeField] float maxMana;
    [SerializeField] float ammountOfMana;
    ManaPool manaPool;
    // Start is called before the first frame update
    void Awake()
    {
        manaPool = ManaPool.Instance;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        projectile = transform;
    }
    // Update is called once per frame
    void Update()
    {
        
        projectile.LookAt(playerTransform);
        projectile.position += projectile.forward * (speedOfProjectile * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if ((manaPool.remainingMana + ammountOfMana) > maxMana)
                manaPool.remainingMana = maxMana;
            else manaPool.AddMana(ammountOfMana);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAllies : MonoBehaviour
{
    [SerializeField] float healingAmount = 5;
    [SerializeField] GameObject healPrefab;
    [SerializeField] float spawnHealEvery = 0.5f;

    GameObject healAnimation;
    float elapsedSeconds;
    bool startTimer= false;
    bool shouldSpawnHeal = true;
    Health health;
    void Start()
    {
        health = GetComponent<Ally>().health;
    }
    private void Update()
    {
        if (startTimer)
        {
            elapsedSeconds += Time.deltaTime;
            if(elapsedSeconds > spawnHealEvery)
            {
                shouldSpawnHeal = true;
                elapsedSeconds = 0;
                startTimer = false;
            }
        }    
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("HealingZone"))
        {
            health.Heal(healingAmount * Time.fixedDeltaTime);
            if (shouldSpawnHeal)
            {
                SpawnHeal();
                startTimer = true;
                shouldSpawnHeal = false;
            }
        }
    }
    void SpawnHeal()
    {
        healAnimation = Instantiate(healPrefab, transform.position, Quaternion.identity);
        healAnimation.transform.parent = gameObject.transform;
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnAllies : MonoBehaviour
{
    [SerializeField] float allowedDistanceToSpawn;
    [SerializeField] GameObject[] necroRings;
    [SerializeField] GameObject[] allyTypes;

    ManaPool manaPool;
    GameObject spawningObject;
    float actualDistance;
    bool buttonsActive = false;
    Camera mainCamera;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        mainCamera = Camera.main;
        manaPool = ManaPool.Instance;
    }

    private void Update()
    {
        if (SpawnAlliesUi.Instance.buttonsActive)
        {
            if (!IsMouseOverUI() && Input.GetMouseButtonDown(0))
                SpawnAlliesUi.Instance.ChangeButtosActivity();
            if (spawningObject != null)
                actualDistance = Vector3.Distance(_player.transform.position, spawningObject.transform.position);
            if (allowedDistanceToSpawn <= actualDistance)
            {
                SpawnAlliesUi.Instance.ChangeButtosActivity();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Spawner")))
            {
                if (hit.collider.gameObject.CompareTag("SpawningAlly"))
                {
                    spawningObject = hit.collider.gameObject;
                    actualDistance = Vector3.Distance(_player.transform.position, spawningObject.transform.position);
                    if (allowedDistanceToSpawn >= actualDistance && !spawningObject.GetComponent<SpawnTarget>().isSpawning)
                    {
                        SpawnAlliesUi.Instance.ChangeButtosActivity();
                    }
                }
            }
        }
    }

    public void TaskOnClick(int index)
    {
       // if (TriggerBattleCollider.canSpawn)
       // {
            SpawnAlliesUi.Instance.ChangeButtosActivity();
            if (manaPool.remainingMana >= manaPool.resurretionCost)
            {
                var spawnTarget = spawningObject.gameObject.GetComponent<SpawnTarget>();
                if (spawnTarget.isSpawning) return;

                spawnTarget.StartSpawning(allyTypes[index], necroRings[index]);
                AudioHolder.Instance.PlayResurrectionSound();
                manaPool.CastedResurretion();
            }
            else print("Not enough mana for resurrection");
       // }
    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
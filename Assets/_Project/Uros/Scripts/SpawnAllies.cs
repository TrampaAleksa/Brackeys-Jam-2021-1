using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnAllies : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject[] buttonsObjects;
    Camera mainCamera;
    [SerializeField] float allowedDistanceToSpawn;
    Transform spawningPlace;
    float actualDistance;
    bool buttonsActive = false;
    
    GameObject spawningObject;
    [SerializeField] GameObject[] necroRings;
    [SerializeField] GameObject[] allyTypes;

    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        mainCamera = Camera.main;
        for (int i = 0; i < buttons.Length; i++)
        {
            Button btns = buttons[i].GetComponent<Button>();
            int indexOfButton = i;
            buttons[indexOfButton].onClick.AddListener(() => TaskOnClick(indexOfButton));
        }
    }

    private void Update()
    {
        if (buttonsActive)
        {
            if (!IsMouseOverUI() && Input.GetMouseButtonDown(0))
                ChangeButtosActivity();
            if (spawningObject != null)
                actualDistance = Vector3.Distance(_player.transform.position, spawningPlace.position);
            if (allowedDistanceToSpawn <= actualDistance)
            {
                ChangeButtosActivity();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("SpawningAlly"))
                {
                    spawningObject = hit.collider.gameObject;
                    spawningPlace = spawningObject.transform;
                    actualDistance = Vector3.Distance(_player.transform.position, spawningPlace.position);
                    if (allowedDistanceToSpawn >= actualDistance && !spawningObject.GetComponent<SpawnTarget>().isSpawning)
                    {
                        ChangeButtosActivity();
                    }
                }
            }
        }
    }

    public void TaskOnClick(int index)
    {
        ChangeButtosActivity();

        var spawnTarget = spawningObject.gameObject.GetComponent<SpawnTarget>();
        if (spawnTarget.isSpawning) return;

        spawnTarget.StartSpawning(allyTypes[index], necroRings[index]);

        //ally.transform.parent = spawningObject.transform;
        //ally.transform.GetChild(0).gameObject.SetActive(false) ;
    }

    void ChangeButtosActivity()
    {
        for (int i = 0; i < buttonsObjects.Length; i++)
        {
            buttonsObjects[i].SetActive(!buttonsActive);
        }

        buttonsActive = !buttonsActive;
    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}

public class SpawnAlliesUi : MonoBehaviour
{
    public static SpawnAlliesUi Instance;
    
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject[] buttonsObjects;
    
    public bool buttonsActive;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeButtosActivity()
    {
        for (int i = 0; i < buttonsObjects.Length; i++)
        {
            buttonsObjects[i].SetActive(!buttonsActive);
        }

        buttonsActive = !buttonsActive;
    }
}
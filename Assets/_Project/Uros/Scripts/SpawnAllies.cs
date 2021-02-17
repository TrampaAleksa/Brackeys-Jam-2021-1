using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float elapsedTime;
    int indexOfSpawningAlly;
    bool startSpawning = false;
    [SerializeField] float timeTillSpawn = 4f;
    GameObject ally;
    AllyList allyList;
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
                    actualDistance = Vector3.Distance(gameObject.transform.position, spawningPlace.position);
                    print(actualDistance);                
                    if (allowedDistanceToSpawn >= actualDistance)
                    {
                        ChangeButtosActivity();
                    }
                }
            }
        }
        if (buttonsActive)
        {
            if (spawningObject != null)
                actualDistance = Vector3.Distance(gameObject.transform.position, spawningPlace.position);
            if (allowedDistanceToSpawn <= actualDistance || Input.GetMouseButtonDown(1))
            {
                ChangeButtosActivity();
            }
        }
        if (startSpawning)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= timeTillSpawn)
            {
                SpawnAlly();
            }
        }
        
    }
    public void TaskOnClick(int index)
    {
        if (!startSpawning)
        {
            ChangeButtosActivity();
            Instantiate(necroRings[index], spawningPlace.position, Quaternion.identity);
            startSpawning = true;
            indexOfSpawningAlly = index;
        }
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

    void SpawnAlly()
    {
        //ally.GetComponent<Animator>().enabled = false;
        //ally.transform.GetChild(0).gameObject.SetActive(true);
        ally = Instantiate(allyTypes[indexOfSpawningAlly], spawningObject.transform.position, Quaternion.identity);
        allyList = AllyList.Instance;        
        allyList.AllyRaised(ally.GetComponent<Ally>());
        spawningObject.transform.DetachChildren();
        Destroy(spawningObject);
        elapsedTime = 0;
        startSpawning = false;
    }
    private void OnMouseEnter()
    {
        
    }
}
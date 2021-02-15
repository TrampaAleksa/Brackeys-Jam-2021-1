using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMoveme : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            transform.LookAt(player.transform);
    }
}

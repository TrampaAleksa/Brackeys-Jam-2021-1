using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovementBattle : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    GameObject player;
    NavMeshAgent navMeshAgent;
    public bool isRetreating = false;
    [SerializeField]
    float radiusInBattle = 1f;
    GameObject lookAt;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRetreating)
        {
            navMeshAgent.SetDestination(target.transform.transform.position);
            lookAt = target;
        }
        else
        {
            navMeshAgent.SetDestination(player.transform.position);
            lookAt = player;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isRetreating = true;
        }
        if (Input.GetMouseButtonDown(1))
            isRetreating = false;
         if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            transform.LookAt(lookAt.transform);
        navMeshAgent.radius = radiusInBattle;
    }

}

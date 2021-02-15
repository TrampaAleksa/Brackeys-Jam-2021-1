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
    GameObject lookAt;
    // Start is called before the first frame update
    void Start()
    {
        // ako se ne krece koristi look at
        //transform.LookAt(target.transform);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      
        //retreat
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
    }

}

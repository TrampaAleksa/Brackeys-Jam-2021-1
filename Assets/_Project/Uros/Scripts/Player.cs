using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool inBattle = false;
    GameObject[] allies;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BattleArea"))
        {       
            allies = GameObject.FindGameObjectsWithTag("Ally");
            inBattle = !inBattle;
            gameObject.GetComponent<RetreatAlly>().enabled = inBattle;
            for (int i = 0; i < allies.Length; i++)
            {
                allies[i].GetComponent<AIMovementBattle>().enabled = inBattle;
                allies[i].GetComponent<AIMovement>().enabled = !inBattle;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BattleArea"))
        {
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}

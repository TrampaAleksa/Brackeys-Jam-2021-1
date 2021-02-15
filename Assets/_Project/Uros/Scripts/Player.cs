using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool inBattle = false;
    RetreatAlly retreatAlly;
    GameObject[] allies;
    AIMovementBattle[] aIMovementBattles;
    int numberOfAllies = 0;
    GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        allies = GameObject.FindGameObjectsWithTag("Ally");
    }

    // Update is called once per frame
    void Update()
    {       
        ChangeBattleArea();
    }
    void ChangeBattleArea()
    {
        if (Input.GetAxis("Jump") != 0)
        {
            inBattle = !inBattle;
            
            gameObject.GetComponent<RetreatAlly>().enabled = inBattle;
            
            for(int i =0; i< allies.Length; i++)
            {
                allies[i].GetComponent<AIMovementBattle>().enabled = inBattle;
                allies[i].GetComponent<AIMovement>().enabled = !inBattle;
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BattleArea"))
        {
            inBattle = !inBattle;

            gameObject.GetComponent<RetreatAlly>().enabled = inBattle;

            for (int i = 0; i < allies.Length; i++)
            {
                allies[i].GetComponent<AIMovementBattle>().enabled = inBattle;
                allies[i].GetComponent<AIMovement>().enabled = !inBattle;
            }
        }
    }
}

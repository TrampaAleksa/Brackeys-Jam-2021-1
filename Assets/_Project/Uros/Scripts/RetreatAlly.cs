
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatAlly : MonoBehaviour
{
    /*
    Camera mainCamera;
    Ally ally;
    ManaPool manaPool;
    void Start()
    {
        mainCamera = Camera.main;
        manaPool = ManaPool.Instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Ally"))
                {
                    
                    ally = hit.collider.GetComponent<Ally>();
                    if (manaPool.remainingMana >= manaPool.retreatCost)
                    {
                        if (ally.movement.state == AllyMovementState.InBattle)
                        {
                            ally.movement.state = AllyMovementState.Retreating;
                            manaPool.CastedRetreat();
                            print("Did Hit");
                        }
                    }
                    
                }
            }
        }
    }
    */
}

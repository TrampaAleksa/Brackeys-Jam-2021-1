using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatAlly : MonoBehaviour
{
    Camera mainCamera;
    Ally ally;
    void Start()
    {
        mainCamera = Camera.main;
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
                    ally.aiMovementBattle.isRetreating = true;
                    Debug.Log("Did Hit");
                }
            }
        }
    }
}

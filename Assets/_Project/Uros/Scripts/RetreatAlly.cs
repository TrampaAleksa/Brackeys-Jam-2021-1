using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatAlly : MonoBehaviour
{
    Camera mainCamera;
    AIMovementBattle aiMovementBattle;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
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
                    aiMovementBattle = hit.collider.GetComponent<AIMovementBattle>();
                    aiMovementBattle.isRetreating = true;
                    Debug.Log("Did Hit");
                }
            }
        }
    }
}

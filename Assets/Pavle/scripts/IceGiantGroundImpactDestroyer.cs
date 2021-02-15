using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGiantGroundImpactDestroyer : MonoBehaviour
{
    public float xSeconds = 3.6f;

    private void Start()
    {
        StartCoroutine(waitAndDestroy());
    }


    private IEnumerator waitAndDestroy()
    {
        yield return new WaitForSeconds(xSeconds);
        Destroy(transform.gameObject);
    }
}

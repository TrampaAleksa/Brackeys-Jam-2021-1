using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoInteraction : MonoBehaviour
{
    public Transform tornadoCenter;
    public float pullForce;
    public float refreshRate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "box")
        {
            StartCoroutine(pullObject(other,true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "box")
        {
            StartCoroutine(pullObject(other, false));
        }/////////////
    }

    IEnumerator pullObject(Collider col,bool pull) 
    {
        if (pull)
        {
            Vector3 forceDirection = tornadoCenter.position - col.transform.position;
            col.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.deltaTime);
            yield return refreshRate;
            StartCoroutine(pullObject(col, true));
        }
    }
}

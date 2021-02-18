using System;
using UnityEngine;

public class GnomeSpawnAlly : MonoBehaviour
{
    public Ally gnomeAttacker;
    public int gnomeLimit = 5;

    private Transform _gnomeTransform;
    private int _numberOfGnomes;
    private void Update()
    {
        _gnomeTransform = transform;

        for (int i = 0; i < gnomeLimit; i++)
        {
            var gnomeAttackedSpawned = Instantiate(gnomeAttacker, _gnomeTransform.position + gnomeAttacker.transform.position, _gnomeTransform.rotation);
            AllyList.Instance.AllyRaised(gnomeAttackedSpawned);
        }

        AllyList.Instance.allies.Remove(GetComponent<Ally>());
        Destroy(gameObject);
    }
}

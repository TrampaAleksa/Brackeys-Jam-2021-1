using UnityEngine;

public class ProjectileHolder : MonoBehaviour
{
    public static ProjectileHolder Instance;
    public GameObject toInstantiate;

    public Transform projectileHolderTransform;

    private void Awake()
    {
        Instance = this;
        projectileHolderTransform = transform.GetChild(0);
    }

    public void BossDiedEvent(Health health)
    {
        health.died = null;
        Destroy(projectileHolderTransform.gameObject);
        projectileHolderTransform = Instantiate(toInstantiate, transform).transform;
    }
}
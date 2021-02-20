using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    [SerializeField] float timeTillSpawn = 2.8f;
    
    private Transform _spawnTransform;
    public bool isSpawning;

    private void Awake()
    {
        _spawnTransform = transform;
    }

    public void StartSpawning(GameObject ally, GameObject necroRing)
    {
        isSpawning = true;
        Instantiate(necroRing, _spawnTransform.position, Quaternion.identity);
        allyToSpawn = ally;
        gameObject.AddComponent<TimedAction>().StartTimedAction(SpawnAlly , timeTillSpawn);
    }

    private GameObject allyToSpawn;
    private void SpawnAlly()
    {
        var allyList = AllyList.Instance;        
        var ally = Instantiate(allyToSpawn, _spawnTransform.position, Quaternion.identity, allyList.transform);
        allyList.AllyRaised(ally.GetComponent<Ally>());
        
        Destroy(gameObject);
    }
}
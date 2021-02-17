using UnityEngine;

public class EarthGolemWindAttack : Attack
{
    public GameObject windObj;
    public float intervalOfDamage;
    
    private TimedAction _timedAction;

    private void Awake()
    {
        _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
    }

    public override void LaunchAttack(Transform target)
    {
        base.LaunchAttack(target);
        print("Launching spike attack!");

        Instantiate(windObj, transform);
        _timedAction.StartTimedAction(DamageAllAllies, intervalOfDamage);
    }

    private void DamageAllAllies()
    {
        foreach (var ally in AllyList.Instance.allies)
        {
            ally.hitDetector.HitByAttack(type, baseDamage);
        }
        
        _timedAction.StartTimedAction(DamageAllAllies, intervalOfDamage);
    }
    
    
}
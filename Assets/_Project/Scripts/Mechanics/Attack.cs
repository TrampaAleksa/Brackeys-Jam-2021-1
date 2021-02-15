using UnityEngine;

public class Attack : MonoBehaviour
{
    public AttackType type;
    public float baseDamage;
    
    
    public virtual void LaunchAttack(Transform target)
    {
        
    }
}


public enum AttackType
{
    Fire,
    Ice,
    Warrior,
    Gnome,
    Wind,
    Reaper,
    Spider
}
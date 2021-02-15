using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform _currentTarget;
    private Transform _projectileTransform;
    
    private float _projectileSpeed;
    private AttackType _type;
    private float _baseAttackDamage;

    private void Awake()
    {
        _projectileTransform = transform;
    }

    public void ChaseTarget(Transform target, float projectileSpeed, AttackType type, float baseAttackDamage)
    {
        _currentTarget = target;
        _projectileSpeed = projectileSpeed;
        _type = type;
        _baseAttackDamage = baseAttackDamage;
    }

    private void Update()
    {
        _projectileTransform.LookAt(_currentTarget);
        _projectileTransform.position += _projectileTransform.forward * (_projectileSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == _currentTarget.name)
        {
            print("Projectile hit the target! ");
            other.GetComponent<AttackHitDetector>().HitByAttack(_type, _baseAttackDamage);
            
            Destroy(gameObject);
        }
    }
}
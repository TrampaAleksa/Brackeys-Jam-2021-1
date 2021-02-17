using UnityEngine;

public class ReaperCleaveCollider : MonoBehaviour
{
    public AttackType type;
    public float baseAttackDamage;

    private Transform _cleaveTransform;
    [SerializeField] private float movementSpeed;

    private void Awake()
    {
        _cleaveTransform = transform;
    }

    private void Update()
    {
        _cleaveTransform.position += _cleaveTransform.forward * (movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ally"))
        {
            other.GetComponent<Ally>().hitDetector.HitByAttack(type, baseAttackDamage);
        }
    }
}
using _Project.Scripts.Utility;
using UnityEngine;

public class EarthGolemHitDetector : AttackHitDetector
{
    [SerializeField] GameObject manaProjectile;
    [SerializeField] GameObject[] collliders;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public override void HitByAttack(AttackType attackType, float baseAttackDamage)
    {
        _health.TakeDamage(baseAttackDamage);
        print("Earth goldem took: " + baseAttackDamage + " damage");

        if (_health.currentHealth <= 0.001f)
        {
            AllyList.Instance.ExitAllyCombat();
            AudioHolder.Instance.earthGolemDeath.Play();
            DestroyColliders();
            Instantiate(manaProjectile, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void DestroyColliders()
    {
        for (int i = 0; i < collliders.Length; i++)
        {
            Destroy(collliders[i]);
        }
    }
}
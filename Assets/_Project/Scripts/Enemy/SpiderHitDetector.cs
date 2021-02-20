using UnityEngine;
public class SpiderHitDetector : AttackHitDetector
{
    [SerializeField] GameObject manaProjectile;
    [SerializeField] GameObject[] collliders;

    private float damageReduction = 0.2f;
    private Health _health;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public override void HitByAttack(AttackType attackType, float baseAttackDamage)
    {
        var totalDamageTaken = baseAttackDamage;

        if (attackType == AttackType.Fire)
            totalDamageTaken *= damageReduction;
        
        _health.TakeDamage(totalDamageTaken);
        print("Spider took: " + totalDamageTaken +  " damage");

        if (_health.currentHealth <= 0.001f)
        {
            AudioHolder.Instance.spiderDeath.Play();
            AllyList.Instance.ExitAllyCombat();
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
public class SpiderHitDetector : AttackHitDetector
{
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
            AllyList.Instance.ExitAllyCombat();
            Destroy(gameObject);
        }
    }
}
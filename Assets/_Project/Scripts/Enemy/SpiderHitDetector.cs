using UnityEngine;
public class SpiderHitDetector : AttackHitDetector
{
    [SerializeField] GameObject manaProjectile;
    [SerializeField] GameObject colllider;

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
            AudioHolder.Instance.TurnOffBossMusic();
            AllyList.Instance.ExitAllyCombat();
            colllider.SetActive(false);
            Instantiate(manaProjectile, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
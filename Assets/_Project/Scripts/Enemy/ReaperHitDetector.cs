public class ReaperHitDetector : AttackHitDetector
{
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
            AudioHolder.Instance.reaperDeath.Play();
            print("WON THE GAME");
            Destroy(gameObject);
        }
    }
}
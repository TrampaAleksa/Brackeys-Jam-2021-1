using _Project.Scripts.Utility;
using UnityEngine;

public class EarthGolemHitDetector : AttackHitDetector
{
    [SerializeField] GameObject manaProjectile;
    [SerializeField] GameObject colllider;

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
            colllider.SetActive(false);
            AudioHolder.Instance.TurnOffBossMusic();
            Instantiate(manaProjectile, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
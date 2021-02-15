using UnityEngine;

public class AttackHitDetector : MonoBehaviour
{
    public void HitByAttack(AttackType attackType, float baseAttackDamage)
    {
        print("Hit by attack of type: " + attackType + "with base damage of: " + baseAttackDamage);
    }
}
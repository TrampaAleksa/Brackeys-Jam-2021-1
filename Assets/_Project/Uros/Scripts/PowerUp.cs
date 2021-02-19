using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float multiplyScale;
    [SerializeField] float multiplyDamage;

    Camera mainCamera;
    ManaPool manaPool;
    Health health;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        manaPool = ManaPool.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ally")))
            {
                if (hit.collider.gameObject.CompareTag("Ally") && hit.collider.GetComponentInChildren<Attack>().type != AttackType.Gnome)
                {
                    powerUpAlly(hit.collider.gameObject);
                }
            }
        }
    }
    void powerUpAlly(GameObject ally)
    {
        if (ally.transform.localScale.x == 1)
        {
            if (manaPool.remainingMana >= manaPool.powerUpCost)
            {
                manaPool.CastedPowerUp();
                Vector3 newScale = ally.transform.localScale;
                newScale.x *= multiplyScale;
                newScale.y *= multiplyScale;
                newScale.z *= multiplyScale;
                ally.transform.localScale = newScale;
                health = ally.GetComponentInChildren<Health>();
                health.maxHealth *= 2;
                health.Heal(health.maxHealth * 2);
                if (ally.GetComponentInChildren<Attack>().type == AttackType.Warrior)
                {
                    ally.GetComponentInChildren<WarriorMeleeAttack>().baseDamage *= multiplyDamage;
                }else ally.GetComponentInChildren<ProjectileAttack>().baseDamage *= multiplyDamage;

            }
        }
    }
}

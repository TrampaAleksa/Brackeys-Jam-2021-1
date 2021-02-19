using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealthBarUpdater : MonoBehaviour
{
    private Health _health;
    public SpriteRenderer foregroundBar;

    private void Awake()
    {
        _health = transform.parent.GetComponent<Health>();
        _health.healthChanged += UpdateHealth;
    }

    public void UpdateHealth()
    {
        var foregroundBarTransform = foregroundBar.transform;
        
        foregroundBarTransform.localScale = new Vector3(
            _health.currentHealth / _health.maxHealth,
            foregroundBarTransform.localScale.y,
            foregroundBarTransform.localScale.z);
    }
}

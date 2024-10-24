using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action onDamaged, onDeath;

    [Header("Data")]
    [SerializeField]
    private int startHealth = 3;

    [Header("Components")]
    [SerializeField]
    private PlayerMomement movement;

    [SerializeField]
    private HealthUI healthUI;

    [SerializeField]
    private Damagable damagable;

    [Header("Stats")]
    [SerializeField]
    private int currentHealth;

    public int CurrentHealth => currentHealth; 

    private void Start()
    {
        currentHealth = startHealth;
        healthUI.SetHearts(startHealth);
        damagable.OnHit += OnDamaged;
    }

    private void OnDamaged()
    {
        healthUI.RemoveHearth();
        currentHealth--;

        onDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
        }
    }
}

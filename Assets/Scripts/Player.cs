using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action onDamaged, onDeath;

    [SerializeField]
    private PlayerData data;

    [Header("Components")]
    [SerializeField]
    private PlayerMomement movement;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private HealthUI healthUI;

    [SerializeField]
    private Damagable damagable;

    [Header("Stats")]
    [SerializeField]
    private int currentHealth;

    public int CurrentHealth => currentHealth;

    private Vector3 spawnPosition;

    public void RespawnPlayer(float duration)
    {
        animator.SetBool("IsDead", false);
        transform.DOMove(spawnPosition, duration).SetUpdate(true);
        currentHealth = data.StartHealth;
        healthUI.SetHearts(currentHealth);
    }

    public void KillPlayer()
    {
        animator.SetBool("IsDead", true);

    }

    private void Awake()
    {
        spawnPosition = transform.position;
    }

    private void Start()
    {
        currentHealth = data.StartHealth;
        healthUI.SetHearts(data.StartHealth);
        damagable.OnHit += OnDamaged;
    }

    private void OnDamaged()
    {
        if (currentHealth <=0)
        {
            return;
        }

        healthUI.RemoveHeart();
        currentHealth--;

        onDamaged?.Invoke();

        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
        }
    }
}

using DG.Tweening;
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
        currentHealth = startHealth;
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
        currentHealth = startHealth;
        healthUI.SetHearts(startHealth);
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

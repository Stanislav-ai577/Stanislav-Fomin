using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth;
    private int _healing;

    public static Action EnemyDie;

    private void Awake()
    {
        _healing += 20;
        _maxHealth = 100;
        _currentHealth = _maxHealth;

    }

    private void OnEnable()
    {
        PlayerHealth.PlayerDie += HealingEnemy;
    }
    
    private void OnDisable()
    {
        PlayerHealth.PlayerDie -= HealingEnemy;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentException("Damage most be positive");
        }
        
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            DieEnemy();
        }
    }

    private void DieEnemy()
    {
        EnemyDie?.Invoke();
        Destroy(gameObject);
    }

    private void HealingEnemy()
    {
        _currentHealth += _healing;
    }
}

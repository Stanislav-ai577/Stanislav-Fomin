using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _currentHealth;
    private int _maxHealth;
    private int _healing;
    
    public static Action PlayerDie;
    
    private void Awake()
    {
        _maxHealth = 100;
        _healing = 20;
        _currentHealth = _maxHealth;
    }
    
    private void OnEnable()
    {
        EnemyHealth.EnemyDie += HealingPlayer;
    }
    
    private void OnDisable()
    {
        EnemyHealth.EnemyDie -= HealingPlayer;
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
            DiePlayer();
        }
    }

    private void DiePlayer()
    {
        PlayerDie?.Invoke();
        Destroy(gameObject);
    }
    
    private void HealingPlayer()
    {
        _currentHealth += _healing;
    }
}

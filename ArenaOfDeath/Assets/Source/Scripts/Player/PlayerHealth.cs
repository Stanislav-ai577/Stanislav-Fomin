using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerHealth : MonoBehaviour,IDamage
{
    [SerializeField] private float _health = 10f;
    [SerializeField] private Animator _animator;
    private bool _isDie = false;
    
    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void TakeDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentException("Damage most be positive.");

        if (_isDie)
            return;

        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        _isDie = true;
        Destroy(gameObject);
    }
}

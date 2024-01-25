using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action onDie;

    [SerializeField] private float _maxHealth;
    private float _health;
    private Coroutine _bonusTick;

    public bool IsTookBonus { get; private set; }

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage must be positive");
        }
        _health -= damage;
        if (_health < 0)
        {
            onDie?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Bonus bonus))
        {
            if (IsTookBonus)
            {
                return;
            }
            IsTookBonus = true;
            _bonusTick = StartCoroutine(BonusTick(bonus.Time));
            bonus.Destroy();
        }
    }

    private IEnumerator BonusTick(float time)
    {
        yield return new WaitForSeconds(time);
        IsTookBonus = false;
    }
}

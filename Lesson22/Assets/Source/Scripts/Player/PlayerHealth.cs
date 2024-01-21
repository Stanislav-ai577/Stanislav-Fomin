using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnDie;

    [SerializeField] private float _maxHealth;
    
    private float _health;
    private Coroutine _bonusTick;

    public bool isTookBonus { get; private set; }

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
            OnDie?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out BonusDamage bonusDamage))
        {
            if (isTookBonus)
                return;
            isTookBonus = true;
            bonusDamage.Destroy();
            _bonusTick = StartCoroutine(BonusTick(bonusDamage.TimeBonusDamage));
        }
    }
    
    

    private IEnumerator BonusTick(float time)
    {
        yield return new WaitForSeconds(time);
        isTookBonus = false;
    }
}

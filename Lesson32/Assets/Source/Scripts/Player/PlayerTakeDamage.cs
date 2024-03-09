using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField] private int _playerDamage;
    private int _addDamage;

    private void Awake()
    {
        _addDamage += 20;
        _playerDamage = 5;
    }

    private void OnEnable()
    {
        EnemyHealth.EnemyDie += DamageUp;
    }
    
    private void OnDisable()
    {
        EnemyHealth.EnemyDie -= DamageUp;
    }

    private void DamageUp()
    {
        _playerDamage += _addDamage;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
      
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(_playerDamage);
        }
    }
}

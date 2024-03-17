using UnityEngine;
public class Minion : Enemy
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private int _currentArmor;
    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        Move();
    }
    
    public override void SetupPosition(Transform player)
    {
        _targetPosition = player;
    }
    
    public override void Move()
    {
        Vector3 direction = (_targetPosition.position - transform.position).normalized;
        _rigidbody.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ammo ammo))
        {
            TakeDamage(ammo.Damage);
        }
    }

    public override void TakeDamage(int damage)
    {
        _currentArmor = Mathf.Clamp(_currentArmor - damage, 0, _currentArmor);

        if (_currentArmor <= 0)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _currentHealth);
        }

        if (_currentHealth == 0)
        {
            Die();
        }
    }
    
    public override void Die()
    {
        Destroy(gameObject);
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IMove
{
    [SerializeField] private Vector3 _transformEnemy;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Enemy _enemy;
    [SerializeField, Range(0, 5)] private int _speedPlayer;
    [SerializeField, Range(0, 10)] private int _force;
    [SerializeField, Range(0, 100)] private int _maxHealth;
    [SerializeField, Range(0, 100)] private int _damage;
    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transformEnemy = this.transform.position;
        _damage = UnityEngine.Random.Range(1, 100);
        _currentHealth = _maxHealth;
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (_enemy == null)
        {
            return;
        }
        
        transform.LookAt(_transformEnemy); 
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX; 
        transform.position = Vector3.Lerp(transform.position, _transformEnemy, Time.fixedDeltaTime * _speedPlayer);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new AggregateException("Damage most be positive");
        }
        
        _currentHealth -= damage;
        
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Vector3 direction = transform.position - collision.transform.position;
            _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
            Attack(_enemy);
        }
        
    }
}

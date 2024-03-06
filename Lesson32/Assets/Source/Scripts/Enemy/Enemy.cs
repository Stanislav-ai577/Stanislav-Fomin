using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IMove
{
    [SerializeField] private Transform _transformPlayer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Player _player;
    [SerializeField, Range(0, 5)] private int _speedEnemy;
    [SerializeField, Range(0, 10)] private int _force;
    [SerializeField, Range(0, 100)] private int _maxHealth;
    [SerializeField, Range(0, 100)] private int _damage;
    [SerializeField] private int _currentHealth;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Player instatinate = Instantiate(_player, new Vector3(0, 0, 0), Quaternion.identity);
        _player = instatinate;
        _damage = UnityEngine.Random.Range(1, 100);
        _currentHealth = _maxHealth;
        
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {
        if (_player == null)
        {
            return;
        } 
        
        transform.LookAt(_player.transform.position);
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, Time.fixedDeltaTime * _speedEnemy);
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
    
    private void Attack(Player player)
    {
        player.TakeDamage(_damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Vector3 direction = transform.position - collision.transform.position;
            _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
            Attack(_player);
        }
    }
}

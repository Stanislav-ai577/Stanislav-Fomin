using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IMove
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Player _player;
    [SerializeField] private SpawnerPlayer _playerPositionSpawn;
    [SerializeField, Range(0, 10)] private int _speedEnemy;
    [SerializeField, Range(0, 15)] private int _force;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speedEnemy = 5;
        _force = 15;
    }
    
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (_player == null)
        {
            return;
        } 
        
        transform.position = Vector3.MoveTowards(transform.position, _playerPositionSpawn.TargetPlayerPosition, _speedEnemy * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Vector3 direction = transform.position - collision.transform.position;
            _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}

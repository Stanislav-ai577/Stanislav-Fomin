using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IMove
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private SpawnerEnemy _enemyPositionSpawn;
    [SerializeField, Range(0, 10)] private int _speedPlayer;
    [SerializeField, Range(0, 20)] private int _force;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speedPlayer = 5;
        _force = 15;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (_enemy == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _enemyPositionSpawn.TargetEnemyPosition, _speedPlayer * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Vector3 direction = transform.position - collision.transform.position;
            _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}

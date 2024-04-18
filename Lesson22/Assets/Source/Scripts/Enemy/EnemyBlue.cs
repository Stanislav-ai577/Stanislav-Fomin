using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(Rigidbody))]

public class EnemyBlue : MonoBehaviour, IEntryPointSetupPlayer
{
    [SerializeField] private Transform _player;
    private NavMeshAgent _enemy;
    private EnemyHealth _health;

    private void Awake()
    {
        _enemy = GetComponent<NavMeshAgent>();
        _health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (!_player)
            return;
        _enemy.SetDestination(_player.position);
    }

    public void Setup(PlayerMovement player)
    {
        _player = player.transform;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out PlayerHealth health))
        {
            if (!health.isTookBonus)
                health.TakeDamage(1);
            else
                _health.TakeDamage(1);
        }
    }
}

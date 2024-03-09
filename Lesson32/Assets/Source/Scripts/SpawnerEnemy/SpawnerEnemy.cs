using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    public Vector3 TargetEnemyPosition { get; private set; }

    private void Awake()
    {
        _enemy = Resources.Load<Enemy>("Enemy/Enemy");
    }

    private void OnEnable()
    {
        EnemyHealth.EnemyDie += EnemySpawner;
    }
    
    private void OnDisable()
    {
        EnemyHealth.EnemyDie -= EnemySpawner;
    }

    private void Start()
    {
        EnemySpawner();
    }

    private void EnemySpawner()
    {
        Enemy instance = Instantiate(_enemy, transform.position, Quaternion.identity);
        TargetEnemyPosition = instance.transform.position;
    }
}

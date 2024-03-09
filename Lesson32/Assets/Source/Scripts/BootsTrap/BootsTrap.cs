using UnityEngine;

public class BootsTrap : MonoBehaviour
{
    [SerializeField] private SpawnerPlayer _spawnerPlayer;
    [SerializeField] private SpawnerEnemy _spawnerEnemy;
    private int _spawnPositionX;
    private int _spawnPositionZ;
    private int _spawnPositionY;

    private void Awake()
    {
        _spawnerPlayer = Resources.Load<SpawnerPlayer>("SpawnerPlayer/SpawnerPlayer");
        _spawnerEnemy = Resources.Load<SpawnerEnemy>("SpawnerEnemy/SpawnerEnemy");
        _spawnPositionX = UnityEngine.Random.Range(0, 20);
        _spawnPositionZ = UnityEngine.Random.Range(0, 20);
        _spawnPositionY = 10;
    }

    private void Start()
    {
        CreatedSpawnerPlayer();
        CreatedSpawnerEnemy();
    }

    private void CreatedSpawnerEnemy()
    {
        SpawnerEnemy spawnerEnemy = Instantiate(_spawnerEnemy, new Vector3(-_spawnPositionX, _spawnPositionY, -_spawnPositionZ), Quaternion.identity);
    }

    private void CreatedSpawnerPlayer()
    {
        SpawnerPlayer spawnerPlayer = Instantiate(_spawnerPlayer, new Vector3(_spawnPositionX, _spawnPositionY, _spawnPositionZ), Quaternion.identity);
    }
}

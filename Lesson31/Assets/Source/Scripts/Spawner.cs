using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _player;
    [SerializeField] private Player _playerList;
    [SerializeField] private Vector3 _spawnvalues;
    private float _spawnDelay;

    private void Awake()
    {
        _enemy = Resources.Load<GameObject>("Enemy");
        _spawnDelay = 1f;
    }

    private void Start()
    {
        StartCoroutine(SpawnTick(_spawnvalues));
    }

    private void Update()
    {
        _spawnvalues = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
    }

    private void SpawnEnemy()
    {
            GameObject enemy = Instantiate(_enemy, _spawnvalues, Quaternion.identity, transform);
            enemy.transform.DOMove(_player.position, Random.Range(5,10));
            _playerList.Enemy.Add(enemy);
    }

    private IEnumerator SpawnTick(Vector3 vector)
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}

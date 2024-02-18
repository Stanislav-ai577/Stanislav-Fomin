using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyEnumSpawner : MonoBehaviour
{
    [field: SerializeField] private List<RandomEnemy> _enemies = new List<RandomEnemy>();
    [SerializeField] private RandomEnemy _randomEnemy;
    [SerializeField] private Vector3 _randomSpawnPoint;

    private void Awake()
    {
        _randomEnemy = Resources.Load<RandomEnemy>("EnemyEnum");
    }
    
    private void Start()
    {
        StartCoroutine(SpawnTick());
    }

    private void SpawnRandomEnemy(Vector3 point)
    {
        RandomEnemy randomEnemy = Instantiate(_randomEnemy, point, Quaternion.identity);
    }

    private IEnumerator SpawnTick()
    {
        yield return new WaitForSeconds(2.0f);
        SpawnRandomEnemy(_randomSpawnPoint = new Vector3(5, Random.Range(0, 5), Random.Range(-4, 5)));
        _enemies.Add(_randomEnemy);
        yield return new WaitForSeconds(2.0f);
        SpawnRandomEnemy(_randomSpawnPoint = new Vector3(5, Random.Range(0, 5), Random.Range(-4, 5)));
        _enemies.Add(_randomEnemy);
        yield return new WaitForSeconds(2.0f);
        SpawnRandomEnemy(_randomSpawnPoint = new Vector3(5, Random.Range(0, 5), Random.Range(-4, 5)));
        _enemies.Add(_randomEnemy);
    }
}

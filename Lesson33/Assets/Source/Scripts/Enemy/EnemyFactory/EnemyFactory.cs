using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemy = new List<GameObject>();
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private GameObject _factory;

    private void Awake()
    {
        LoadEnemy();
    }

    private void Start()
    {
        StartCoroutine(SpawnMinionTick());
    }
    
    private void LoadEnemy()
    {
        GameObject loadMinion = Resources.Load<GameObject>("Enemy/Minion");
        _enemy.Add(loadMinion);
        
        GameObject loadGiant = Resources.Load<GameObject>("Enemy/Giant");
        _enemy.Add(loadGiant);
        
        GameObject loadColossus = Resources.Load<GameObject>("Enemy/Colossus");
        _enemy.Add(loadColossus);
    }
    
    private void SpawnMinion()
    {
        GameObject enemy = _enemy[0];
        GameObject instantiate = Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        instantiate.GetComponent<Minion>().SetupPosition(_targetPosition);
    }
    
    private void SpawnGiant()
    {
        GameObject enemy = _enemy[1];
        GameObject instantiate = Instantiate(enemy, new Vector3(10, 1, 0), Quaternion.identity);
        instantiate.GetComponent<Giant>().SetupPosition(_targetPosition);
    }
    
    private void SpawnColossus()
    {
        GameObject enemy = _enemy[2];
        GameObject instantiate = Instantiate(enemy, new Vector3(-10, 1, 0), Quaternion.identity);
        instantiate.GetComponent<Colossus>().SetupPosition(_targetPosition);
    }
    
    private IEnumerator SpawnMinionTick()
    {
        while (true)
        {
            SpawnMinion();
            yield return new WaitForSeconds(2f);
            StartCoroutine(SpawnGiantTick());
            StartCoroutine(SpawnColossusTick());
        }
    }
    
    private IEnumerator SpawnGiantTick()
    {
        yield return new WaitForSeconds(2f);
        SpawnGiant();
    }
    
    private IEnumerator SpawnColossusTick()
    {
        yield return new WaitForSeconds(2f);
        SpawnColossus();
    }
}

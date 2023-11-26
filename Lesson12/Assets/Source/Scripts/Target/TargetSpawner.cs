using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private TargetFactory _factory;

    private void Awake()
    {
        StartCoroutine(SpawnTick());
    }

    private IEnumerator SpawnTick()
    {
        _factory.CreatedNewTarget(transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
        yield return new WaitForSeconds(2);
        _factory.CreatedNewTarget(transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
        yield return new WaitForSeconds(2);
        _factory.CreatedNewTarget(transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
        yield return new WaitForSeconds(2);
        _factory.CreatedNewTarget(transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
    }
}

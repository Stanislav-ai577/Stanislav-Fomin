using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private TargetFactory _factory;
    [SerializeField] private TextMeshProUGUI _counter;
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

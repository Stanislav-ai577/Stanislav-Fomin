using System.Collections;
using UnityEngine;

public class TargetsSpawner : MonoBehaviour
{
    [SerializeField] private TargetsFactory _factory;
    private void Awake()
    {
        StartCoroutine(SpawnTick());
    }

    private IEnumerator SpawnTick()
    {
        _factory.CreatedNewTarget(transform.position + new Vector3(Random.Range(0, 5), Random.Range(-2, 2), 0));
        yield return new WaitForSeconds(2);
        _factory.CreatedNewTarget(transform.position + new Vector3(Random.Range(0, 5), Random.Range(-2, 2), 0));
        yield return new WaitForSeconds(2);
        _factory.CreatedNewTarget(transform.position + new Vector3(Random.Range(0, 5), Random.Range(-2, 2), 0));
        yield return new WaitForSeconds(2);
        _factory.CreatedNewTarget(transform.position + new Vector3(Random.Range(0, 5), Random.Range(-2, 2), 0));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [field: SerializeField] public List<Resource> ResourcesStorage = new List<Resource>();
    [SerializeField] private Resource _resource;
    [SerializeField] private Transform _worker;
    [SerializeField] private Transform _storage;

    private void Start()
    {
        StartCoroutine(DistanceTick());
    }

    private void DistanceCheker()
    {
        float distanceStorage = Vector3.Distance(_worker.position, _storage.position);
        if (distanceStorage == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                ResourcesStorage.Add(_resource);
            }
        }
    }

    private IEnumerator DistanceTick()
    {
        yield return new WaitForSeconds(16);
        DistanceCheker();
    }
}

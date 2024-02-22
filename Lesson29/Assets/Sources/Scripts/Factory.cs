using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Factory : MonoBehaviour
{
    [field: SerializeField] public List<Resource> FactoriesResources = new List<Resource>();
    [SerializeField] private Resource _resource;
    [SerializeField] private Transform _factory;
    [SerializeField] private Transform _worker;
    private float _distanceWorkerCheck;
    private int _resourceCount;
    
    

    private void Awake()
    {
        _resource = Resources.Load<Resource>("Resource");
    }

    private void Start()
    {
        StartCoroutine(SpawnTick());
    }

    private void CreateReource()
    { 
        Instantiate(_resource,transform.position, Quaternion.identity);
        FactoriesResources.Add(_resource);
        _resourceCount = FactoriesResources.Count;
    }
  
    private IEnumerator SpawnTick()
    {
        while (_resourceCount < 10)
        {
            yield return new WaitForSeconds(1);
            CreateReource();
        }
    }
}

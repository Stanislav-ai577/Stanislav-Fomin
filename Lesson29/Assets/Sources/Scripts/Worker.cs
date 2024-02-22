using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Worker : MonoBehaviour
{
   [field: SerializeField] public List<Resource> WorkerResources = new List<Resource>();
   [SerializeField] private Factory _factory;
   [SerializeField] private Transform _firstFactoryPosition;
   [SerializeField] private Transform _secondFactoryPosition;
   [SerializeField] private Transform _worker;
   [SerializeField] private Transform _storage;
   [SerializeField] private float _moveDuration;
   private float _firstFactoryCheck;
   private int _resourcesCount;

   private void Start()
   {
      WorkerMoveFirstFactory();
      StartCoroutine(AddResourcesFirstFactoryTick());
      StartCoroutine(WorkerMoveSecondFactoryTick());
   }

   private void Update()
   {
      DistanceFactoryCheker();
      
   }

   private void DistanceFactoryCheker()
   {
         float distanceFirstFactory = Vector3.Distance(_worker.position, _firstFactoryPosition.position);
         _firstFactoryCheck = distanceFirstFactory;
   }
   
   private void AddResourcesWorker()
   {
      WorkerResources.AddRange(_factory.FactoriesResources);
      _resourcesCount = WorkerResources.Count;
   }

   private void WorkerMoveFirstFactory()
   {
      transform.DOMove(_firstFactoryPosition.position, _moveDuration);
   }
   
   private IEnumerator AddResourcesFirstFactoryTick()
   {
      while (_resourcesCount < 10)
      {
            yield return new WaitForSeconds(1);
            AddResourcesWorker();
      }
   }
   
   private IEnumerator AddResourcesSecondFactoryTick()
   {
      while (_resourcesCount < 20)
      {
         yield return new WaitForSeconds(1);
         AddResourcesWorker();
      }
   }

   private IEnumerator WorkerMoveSecondFactoryTick()
   {
      if (_firstFactoryCheck == 0)
      {
         yield return new WaitForSeconds(5);
         transform.DOMove(_secondFactoryPosition.position, _moveDuration);
         StartCoroutine(AddResourcesSecondFactoryTick());
      }
      yield return new WaitForSeconds(1);
      StartCoroutine(WorkerMoveStorageTick());
   }
   
   private IEnumerator WorkerMoveStorageTick()
   {
         yield return new WaitForSeconds(1);
         transform.DOMove(_storage.position, _moveDuration);
   }
}

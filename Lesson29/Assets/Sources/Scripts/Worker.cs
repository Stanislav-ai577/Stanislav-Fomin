using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Worker : MonoBehaviour
{
   [field: SerializeField] public List<Resource> firstFactory = new List<Resource>();
   [field: SerializeField] public List<Resource> secondFactory = new List<Resource>();
   [SerializeField] private Transform _factoryPositionFirst;
   [SerializeField] private Transform _factoryPositionSecond;
   [SerializeField] private float _moveDuration;
   [SerializeField] private Resource _resource;
   [SerializeField] private Transform _worker;
   [SerializeField] private Transform _storage;

   private void Start()
   {
      StartCoroutine(WorkerMoveTick());
      StartCoroutine(DinstanceTick());
   }
 
   private void DistanceChecker()
   {
      float distanceFirstFactory = Vector3.Distance(_worker.position, _factoryPositionFirst.position);
      if (distanceFirstFactory == 0)
      {
         for (int i = 0; i < 10; i++)
         {
            firstFactory.Add(_resource);
         }
      }
      
      float distanceSecondFactory = Vector3.Distance(_worker.position, _factoryPositionSecond.position);
      if (distanceSecondFactory == 0)
      {
         for (int i = 0; i < 10; i++)
         {
            secondFactory.Add(_resource);
         }
      }
      
      float distanceStorage = Vector3.Distance(_worker.position, _storage.position);
      if (distanceStorage == 0)
      {
         for (int i = 0; i < 10; i++)
         {
            firstFactory.Clear();
            secondFactory.Clear();
         }
      }
      
   }

   private IEnumerator WorkerMoveTick()
   {
      transform.DOMove(_factoryPositionFirst.position, _moveDuration);
      yield return new WaitForSeconds(5);
      transform.DOMove(_factoryPositionSecond.position, _moveDuration);
      yield return new WaitForSeconds(5);
      transform.DOMove(_storage.position, _moveDuration);
   }
   
   private IEnumerator DinstanceTick()
   {
      yield return new WaitForSeconds(5);
      DistanceChecker();
      yield return new WaitForSeconds(5);
      DistanceChecker();
      yield return new WaitForSeconds(5);
      DistanceChecker();

   }
}

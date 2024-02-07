using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public int Id { get; private set; }

    private void Awake()
    {
        Id = Random.Range(0, 100);
    }

    public  void DeleteEnemy(int i)
    {
        Destroy(gameObject);
    }
}

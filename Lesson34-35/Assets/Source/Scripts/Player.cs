using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private TileSpawner _tileSpawner;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _tileSpawner.SpawnRoad();
    }
}

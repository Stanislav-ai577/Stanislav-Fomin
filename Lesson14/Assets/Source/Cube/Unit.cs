using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Unit : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private MeshRenderer _meshRenderer;
 
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }


    public void Move(Vector3 directiob)
    {
        _rigidbody.AddForce(directiob * _speed, ForceMode.Impulse);
    }
}

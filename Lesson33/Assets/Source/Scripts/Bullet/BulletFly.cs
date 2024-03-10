using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletFly : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody _rigidbody;
    

    [Space(5)] 
    [SerializeField] private float _force;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void FlyBullet(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
    }
    
}

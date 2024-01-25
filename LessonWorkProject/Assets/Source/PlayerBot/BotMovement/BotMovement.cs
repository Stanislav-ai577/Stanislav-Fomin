using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class BotMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBack;
    [SerializeField] private float _speedRotate;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    private float _velosity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) | (Input.GetKey(KeyCode.LeftShift)))
        {
            _velosity += (1 * _speed) * Time.deltaTime;
            _velosity = Math.Clamp(_velosity, 0, 0.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _velosity -= (1 * _speed) * Time.deltaTime;

        }

        float mouseX = Input.GetAxis("Mouse X") * _speedRotate;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        _animator.SetFloat("Velosity", _velosity);
        _rigidbody.velocity = ((transform.rotation * Vector3.forward) * _speed) * _velosity;
    }
}

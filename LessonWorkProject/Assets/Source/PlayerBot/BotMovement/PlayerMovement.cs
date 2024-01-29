using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBack;
    [SerializeField] private float _speedRotate;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    private float _velosity;
    private bool _isHook;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _velosity += (1 * _speed) * Time.deltaTime;
            _velosity = 1;

        }
        else 
        {
                _velosity = 0;
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                {
                    _velosity += (1 * _speed) * Time.deltaTime;
                    _velosity = 2;
                }
            }
            else
            {
                _velosity = 0;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            _velosity -= (1 * _speed) * Time.deltaTime;
            _velosity = -1;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _isHook = true;
        }
        else
        {
            _isHook = false;
        }

        float mouseX = Input.GetAxis("Mouse X") * _speedRotate;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        _animator.SetFloat("Velosity", _velosity);
        _animator.SetBool("IsHook",_isHook);
        _rigidbody.velocity = transform.rotation * Vector3.forward * (_speed * _velosity);
    }
}

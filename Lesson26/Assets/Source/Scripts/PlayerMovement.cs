using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedWalking;
    [SerializeField] private float _speedBack;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _speedRotate;
    [SerializeField] private SounrAreaChek _sounrAreaChek; 
    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _movement;
    private float _mouseX;
    [SerializeField] private bool _isSoundArea;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _sounrAreaChek.OnEnter += SetSoundAreaCheker;
        _sounrAreaChek.OnExit += RemoveSoundAreaCheker;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _mouseX = Input.GetAxis("Mouse X") * _speedRotate;
        transform.rotation *= Quaternion.Euler(0, _mouseX, 0);
        
        if (Input.GetKey(KeyCode.W) && (!Input.GetKey(KeyCode.LeftShift)))
        {
            _movement += (1 * _speedWalking) * Time.deltaTime;
            _movement = Math.Clamp(_movement, 0f, 1f);
            _rigidbody.velocity = transform.rotation * Vector3.forward * (_speedWalking * _movement);
            _animator.SetFloat("Movement", _movement);
        }
        
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift)))
        {
            _movement += (1 * _speedRun) * Time.deltaTime;
            _movement = Math.Clamp(_movement, 1f, 1.2f);
            _rigidbody.velocity = transform.rotation * Vector3.forward * (_speedRun * _movement);
            _animator.SetFloat("Movement", _movement);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            _movement -= (1 * _speedBack) * Time.deltaTime;
            _movement = Math.Clamp(_movement, -1f, 0f);
            _rigidbody.velocity = transform.rotation * Vector3.forward * (_speedBack * _movement);
            _animator.SetFloat("Movement", _movement);
        }
        
        if (!Input.GetKey(KeyCode.W) && (!Input.GetKey(KeyCode.S)))
        {
            _movement = 0;
            _animator.SetFloat("Movement", _movement);
        }
    }

    private void SetSoundAreaCheker()
    {
        _isSoundArea = true;
        _animator.SetBool("Dance", _isSoundArea);
        
    }
    
    private void RemoveSoundAreaCheker()
    {
        _isSoundArea = false;
        _animator.SetBool("Dance", _isSoundArea);
    }
}
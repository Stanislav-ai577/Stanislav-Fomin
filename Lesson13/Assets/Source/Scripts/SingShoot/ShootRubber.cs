using System;
using UnityEngine;

public class ShootRubber : MonoBehaviour
{
    [SerializeField] private float _force = 15;
    public Action OnRealeasesShoot;
    [SerializeField] private float _maxDistance = 3;
    private bool _isCanShoot;
    private Birds _birds;
    private Vector2 _start;
    private Camera _camera;


    private void Awake()
    {
        _camera = Camera.main;
        _start = transform.position;
    }

    public void UpdateBird(Birds bird)
    {
        _birds = bird;
        _isCanShoot = true;
    }

    private void OnMouseDrag()
    {
        if (!_isCanShoot)
            return;
        Vector2 target = _camera.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(_start, target) < _maxDistance)
        {
            transform.position = target;
        }
        else
        {
            Vector2 direction = (target - _start).normalized * _maxDistance;
            transform.position = _start + direction;
        }
    }

    private void OnMouseUp()
    {
        if (!_isCanShoot)
            return;
        Vector2 realesePosition = transform.position;
        transform.position = _start;
        Vector2 delta = realesePosition - _start;
        _birds.Launch(-delta * _force);
        _birds = null;
        _isCanShoot = false;
        OnRealeasesShoot?.Invoke();
    }
}

using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Birds : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    private Rigidbody2D _rigidbody;
    private bool _isCanLaunch = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (_isCanLaunch)
        {
            transform.position = _shootPoint.position;
        }
    }

    public void Setup(Transform shotPoint, Transform startPoint)
    {
        _shootPoint = shotPoint;
        transform.DOJump(shotPoint.position, 0.25f, 4, 5).OnComplete(() =>
        {
            _isCanLaunch = true;
        });
    }

    public void Launch(Vector2 direction)
    {
        _isCanLaunch = false;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(direction, ForceMode2D.Impulse);
    }
}

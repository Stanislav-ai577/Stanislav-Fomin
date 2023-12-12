using UnityEngine;
using DG.Tweening;

public class CircleMove : Circle
{
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
        transform.DOMove(_startPosition + new Vector3(1, 0), 1).OnComplete(() =>
        {
            transform.DOMove(_startPosition + new Vector3(-1, 0), 1);
        }).SetLoops(-1, LoopType.Yoyo);
    }
}

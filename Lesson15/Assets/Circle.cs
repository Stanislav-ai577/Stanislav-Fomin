using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public Action OnClick;
    public Action OnDestroy;

    [SerializeField] private float _lifetime;

    private CounterUI _counter;

    private Vector3 _startPosition;

    private MeshRenderer _renderer;

    private Coroutine _lifeTimeTick;
    private int _score = 1;

    private void Awake()
    {
        _startPosition = transform.position;  
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _lifeTimeTick = StartCoroutine(LifeTimeTick());
    }

    public Circle Setup(CounterUI counter)
    {
        _counter = counter;
        return this;
    }

    public Circle SetMoveType()
    {
        _startPosition = transform.position;
        transform.DOMove(_startPosition + new Vector3(1, 0), 1).OnComplete(() =>
        {
            transform.DOMove(_startPosition + new Vector3(-1, 0), 1);
        }).SetLoops(-1, LoopType.Yoyo);
        return this;
    }

    public Circle SetColor(Color color)
    {
        _renderer.material.color = color;
        return this;
    }

    public Circle SetScore(int score)
    {
        if (score <= 0)
            throw new ArgumentOutOfRangeException("Value must be positive");
        _score = score;
        return this;
    }

    public Circle SetLifetime(float lifetime)
    {
        _lifetime = lifetime;
        return this;
    }

    private void OnMouseDown()
    {
        _counter.AddCount(_score);
        OnClick?.Invoke();
        Kill();
    }

    private IEnumerator LifeTimeTick()
    {
        yield return new WaitForSeconds(_lifetime);
        Kill();
    }

    private void Kill()
    {
        StopCoroutine(_lifeTimeTick);
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }
}
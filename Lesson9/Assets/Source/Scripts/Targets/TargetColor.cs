using System;
using UnityEngine;
using Random = System.Random;

public class TargetColor : Target
{
    private CounterUI _counterTargetColor;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void CollisionTarget()
    {
        Counter();
        _renderer.material.color = Color.yellow;
    }
    
    public virtual void SetCounterTargetColor(CounterUI counter)
    {
        _counterTargetColor = counter;
    }

    public override void Counter()
    {
        _counterTargetColor.AddCount(1);
    }
}

using System.Collections;
using UnityEngine;


public class TargetColor : Target
{
    [SerializeField] private float _waitSwcitchColor;
    private CounterUI _counterTargetColor;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public override void CollisionTarget()
    {
        Counter();
        StartCoroutine(WaitSwitchColorTick());
    }
    
    public virtual void SetCounterTargetColor(CounterUI counter)
    {
        _counterTargetColor = counter;
    }

    public override void Counter()
    {
        _counterTargetColor.AddCount(1);
    }

    private IEnumerator WaitSwitchColorTick()
    {
        yield return new WaitForSeconds(_waitSwcitchColor);
        _renderer.material.color = Color.yellow;
    }
}

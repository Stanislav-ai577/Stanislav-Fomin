using UnityEngine;

public class TargetScale : Target
{
    [SerializeField] private int _scaleTarget;
    private CounterUI _counterTargetScale;
    public override void CollisionTarget()
    {
        Counter();
        transform.localScale = new Vector3(_scaleTarget, _scaleTarget, _scaleTarget);
    }
    
    public virtual void SetCounterTargetScale(CounterUI counter)
    {
        _counterTargetScale = counter;
    }

    public override void Counter()
    {
        _counterTargetScale.AddCount(1);
    }
}

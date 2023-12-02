using UnityEngine;

public class TargetScale : Target
{
    public override void Counter()
    {
        _count++;
        _counter.text = "Score: " + _count.ToString();
        transform.localScale += new Vector3(1, 1, 1);
    }
}

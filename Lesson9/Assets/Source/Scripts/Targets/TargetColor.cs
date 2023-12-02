using UnityEngine;

public class TargetColor : Target
{
    private MeshRenderer _meshRender;

    private void Awake()
    {
        _meshRender = GetComponent<MeshRenderer>();
    }

    public override void Counter()
    {
        _meshRender.material.color = Color.green;
        _count++;
        _counter.text = "Score: " + _count.ToString();
    }
}

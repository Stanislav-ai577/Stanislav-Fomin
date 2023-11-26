using UnityEngine;

public class TargetColor : Target
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public override void TargetsCounter()
    {
        _meshRenderer.material.color = Color.green;
        Destroy(gameObject);
    }
}


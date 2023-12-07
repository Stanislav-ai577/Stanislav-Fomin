using UnityEngine;

[RequireComponent(typeof(MeshRenderer))] 

public class UnitFabric : MonoBehaviour
{
    private Unit _unit;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _unit = Resources.Load<Unit>("Unit");
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public Unit CreateUnit(Vector3 position, Transform parent)
    {
        return Instantiate(_unit, position, Quaternion.identity, parent).GetComponent<Unit>();
    }
}

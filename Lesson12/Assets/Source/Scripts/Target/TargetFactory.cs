using TMPro;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private TextMeshProUGUI _counter;

    private void Awake()
    {
        _target.SetCounter(_counter);
    }

    public void CreatedNewTarget(Vector3 position)
    {
        Instantiate(_target, position, Quaternion.identity);
    }
}

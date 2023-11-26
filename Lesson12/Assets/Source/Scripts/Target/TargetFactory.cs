using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private Target _target;

    public void CreatedNewTarget(Vector3 position)
    {
        Instantiate(_target, position, Quaternion.identity);
    }
}

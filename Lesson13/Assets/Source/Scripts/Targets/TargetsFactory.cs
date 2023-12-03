using UnityEngine;

public class TargetsFactory : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private CounterUI _counter;

    public void CreatedNewTarget(Vector3 position)
    {
       Target targetCreated = Instantiate(_target, position, Quaternion.identity).GetComponent<Target>();
       targetCreated.SetCounter(_counter);
    }
}

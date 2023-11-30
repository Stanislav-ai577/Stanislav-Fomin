using TMPro;
using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Transform _spawnerTargets;


    private void Awake()
    {
            TargetCreated();
    }

    private void TargetCreated()
    {
        for (int i = 0; i < 3; i++)
        {
            Target target = Instantiate(_target, _spawnerTargets.position, Quaternion.identity).GetComponent<Target>();
            target.CreatedNewTarget(_spawnerTargets.position);
        }
    }
}

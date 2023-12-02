using TMPro;
using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private TargetColor _targetColor;
    [SerializeField] private TargetScale _targetScale;
    [SerializeField] private Transform _spawnerTargets;
    [SerializeField] private TextMeshProUGUI _counter;


    private void Awake()
    {
        TargetCreated();
        TargetColorCreated();
        TargetScaleCreated();
    }

    private void TargetCreated()
    {
            Target target = Instantiate(_target, _spawnerTargets.position, Quaternion.identity).GetComponent<Target>();
            target.CreatedNewTarget(_spawnerTargets.position);
            target.SetCounter(_counter);
    }

    private void TargetColorCreated()
    {
        TargetColor targetColor = Instantiate(_targetColor, _spawnerTargets.position, Quaternion.identity).GetComponent<TargetColor>();
        targetColor.CreatedNewTarget(_spawnerTargets.position);
        targetColor.SetCounter(_counter);
    }

    private void TargetScaleCreated()
    {
        TargetScale targetScale = Instantiate(_targetScale, _spawnerTargets.position, Quaternion.identity).GetComponent<TargetScale>();
        targetScale.CreatedNewTarget(_spawnerTargets.position);
        targetScale.SetCounter(_counter);
    }
}

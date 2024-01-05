using TMPro;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private TargetScale _targetScale;
    [SerializeField] private TargetColor _targetColor;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private CounterUI _counter;
    [SerializeField] private CounterUI _counterTargetScale;
    [SerializeField] private CounterUI _counterTargetColor;

    private void Awake()
    {
        TargetCreated();
    }
    
    private void TargetCreated()
    {
        Target target = Instantiate(_target, _spawnPoint.position, Quaternion.identity).GetComponent<Target>();
        TargetScale targetScale = Instantiate(_targetScale, _spawnPoint.position, Quaternion.identity).GetComponent<TargetScale>();
        TargetColor targetColor = Instantiate(_targetColor, _spawnPoint.position, Quaternion.identity).GetComponent<TargetColor>();
        target.SetCounter(_counter);
        targetScale.SetCounterTargetScale(_counterTargetScale);
        targetColor.SetCounterTargetColor(_counterTargetColor);
    }
}

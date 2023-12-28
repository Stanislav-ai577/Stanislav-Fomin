using TMPro;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private CounterUI _counter;
    
    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            TargetCreated();
        }
    }
    
    private void TargetCreated()
    {
        Target target = Instantiate(_target, _spawnPoint.position, Quaternion.identity).GetComponent<Target>();
        target.SetCounter(_counter);
    }
}

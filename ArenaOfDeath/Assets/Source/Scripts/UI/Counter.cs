using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _enemyCount;
    
    private void Update()
    {
        UpdateKillCount();
    }
    
    public void EnemyKillCount(int enemyCount)
    {
        _enemyCount += enemyCount;
        UpdateKillCount();
    }

    private void UpdateKillCount()
    {
        _text.text = _enemyCount.ToString();
    }

}

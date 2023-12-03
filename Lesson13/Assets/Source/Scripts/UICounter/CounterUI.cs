using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private TextMeshProUGUI _text;

    public void AddCount(int amount)
    {
        if (amount < 0)
            return;
        _count += amount;
        UpdateUI();
    }

    public void RemoveCount(int amount)
    {
        if (amount < 0)
            return;
        _count -= amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _text.text = " " + _count.ToString();
    }
}

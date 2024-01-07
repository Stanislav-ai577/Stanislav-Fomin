using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    public Action OnUpdate;
    [SerializeField] private Abilities _abilities;
    [SerializeField] private Wallet _wallet;
    [field: SerializeField] public float Price { get; private set; }
    [field: SerializeField] public float ValuePerClick { get; private set; }
    [field: SerializeField] public float ValuePerSecond { get; private set; }
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TryBuy);
    }

    private void TryBuy()
    {
        if (_wallet.TrySpent(Price))
        {
            Price *= 1.25f;
            OnUpdate?.Invoke();
            _abilities.AddValuePerClick(ValuePerClick);
            _abilities.AddValuePerClick(ValuePerSecond);
        }
    }
}

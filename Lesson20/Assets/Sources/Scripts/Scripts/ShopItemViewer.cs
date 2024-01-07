using System;
using TMPro;
using UnityEngine;

public class ShopItemViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _discription;
    [SerializeField] private ShopItem _item;

    private void Awake()
    {
        UpdateInfo();
        _item.OnUpdate += UpdateInfo;
    }

    private void UpdateInfo()
    {
        _price.text = $"Price: {Math.Round(_item.Price, 1)}";
        _discription.text = "";
        if (_item.ValuePerClick > 0)
        {
            _discription.text += $"Add per click:{_item.ValuePerClick}";
        }
        if (_item.ValuePerSecond > 0)
        {
            _discription.text += $"Add per click:{_item.ValuePerSecond}";
        }
    }
}

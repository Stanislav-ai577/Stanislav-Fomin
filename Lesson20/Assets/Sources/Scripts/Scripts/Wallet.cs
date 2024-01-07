using System;
using System.Collections;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public Action<float> OnValueChange;
    [SerializeField] private Dimond _dimond;
    [SerializeField] private float _value;
    [SerializeField] private Abilities _abilities;
    private Coroutine _secondTick;

    private void Awake()
    {
        _dimond.OnClick += Click;
       _secondTick = StartCoroutine(SecondTick());
    }

    private void OnDisable()
    {
        _dimond.OnClick -= Click;
    }
    
    public bool TrySpent(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Ammount has be positiv");
        if (_value < amount)
        {
            return false;
        }
        else
        {
            RemoveAmount(amount);
            return true;
        }
        return _value > amount;
    }

    private void Click()
    {
        AddAmount(_abilities.ValuePerClick);
    }
    
    private void AddAmount(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Ammount has be positiv");
        _value += amount;
        OnValueChange?.Invoke(_value);
    }
    
    private void RemoveAmount(float amount)
    {
        if (amount < 0)
            throw new ArgumentException("Ammount has be positiv");
        _value -= amount;
        OnValueChange?.Invoke(_value);
    }
    
    private IEnumerator SecondTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            AddAmount(_abilities.ValuePerSecond);
        }
    }
}

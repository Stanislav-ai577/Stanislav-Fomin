using System;
using System.Collections;
using UnityEngine;

public class TargetAction : MonoBehaviour
{
    [SerializeField] private float _colorSwitch;
    private Action TargetActions;
    private Renderer _renderer;

    private void Awake()
    {
        TargetActions += ColorSwitch;
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            TargetActions?.Invoke();
        }
    }

    private void ColorSwitch()
    {
        StartCoroutine(SwitchColorTick());
    }

    private IEnumerator SwitchColorTick()
    {
        yield return new WaitForSeconds(_colorSwitch);
        _renderer.material.color = Color.magenta;
    }
}

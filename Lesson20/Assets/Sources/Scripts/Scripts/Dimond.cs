using System;
using UnityEngine;
using DG.Tweening;

public class Dimond : MonoBehaviour
{
    public Action OnClick;

    public void OnMouseDown()
    {
        OnClick?.Invoke();
        transform.DOScale(0.7f, 0.2f).OnComplete(() =>
        {
            transform.DOScale(0.5f, 0.2f);
        });
    }
}

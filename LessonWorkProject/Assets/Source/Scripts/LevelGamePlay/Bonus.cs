using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [field: SerializeField] public float Time { get; private set; }

    public void Destroy() => Destroy(gameObject);
}

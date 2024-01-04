using System;
using UnityEngine;

public class BoxingUnBoxing : MonoBehaviour
{
    private object _data;
    private int _a;

    private void Awake()
    {
        _a = 10;
        _data = _a;
        _a = (int)_data;

        float a = 5;
        int b = 0;

        a = (float)b;
    }
}

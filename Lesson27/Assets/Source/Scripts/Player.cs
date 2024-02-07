using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemys = new List<Enemy>();
    private float _probabilityDelete; 

    private void Awake()
    {
        _probabilityDelete = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Enemy enemy in _enemys)
            {
                for (int i = 0; i < _enemys.Count; i++)
                {
                    if (_enemys[i].Id % 2 != 0)
                    {
                        _enemys[i].DeleteEnemy(_enemys.Count);
                        _enemys.RemoveAt(i);
                    }
                }
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Random.Range(0, 1f) <= 0.3f)
            {
                for (int i = 0; i < _enemys.Count; i++)
                {
                    _enemys[i].DeleteEnemy(Random.Range(0, _enemys.Count));
                    _enemys.RemoveAt(i);
                }
            }
        }
    }
}

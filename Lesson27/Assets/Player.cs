using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    private int _variable;
    
    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < _enemies.Count; i++)
                {
                    if (_enemies[i].Id % 2 == 1)
                    {
                        _enemies[i].Die(i);
                        _enemies.RemoveAt(i);
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                _variable = Random.Range(0, 10);
               
                if (_variable == 3)
                {
                    for (int i = 0; i < _enemies.Count; i++)
                    {
                        _enemies[i].Die(_variable);
                        _enemies.RemoveAt(i);
                    }
                }
            }
    }
}

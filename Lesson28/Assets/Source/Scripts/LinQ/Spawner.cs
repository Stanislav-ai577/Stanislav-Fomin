using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemyy> _enemyies = new List<Enemyy>();
    [SerializeField] private List<int> _health = new List<int>();
    [SerializeField] private List<int> _healthFiltered;

    private void Awake()
    {
        _healthFiltered = _health.Where(health => health % 2 == 1).ToList();
    }
}

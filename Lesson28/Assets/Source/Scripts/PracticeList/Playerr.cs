using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Playerr : MonoBehaviour
{
    [field: SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [field:SerializeField] private List<Enemy> _enemiesColorRed;
    [field:SerializeField] private List<Enemy> _enemiesColorGreen;
    [field:SerializeField] private List<Enemy> _enemiesColorGreenHealth;
    [SerializeField] private float _randomDamage;
    private int _doubleDamage;

    private void Start()
    {
        _randomDamage = Random.Range(70, 85);
        _doubleDamage = 2;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (i % 2 == 1)
                {
                    _enemies[i].EnemyColor(Color.red);
                    _enemies[i].TakeDamage(_randomDamage);
                }

                if (i % 2 == 0)
                {
                    _enemies[i].EnemyColor(Color.green);
                    _enemies[i].TakeDamage(_randomDamage * _doubleDamage);
                }
            }

            foreach (Enemy enemyColorRed in _enemies)
            {
                if (enemyColorRed.Color == Color.red)
                {
                    _enemiesColorRed.Add(enemyColorRed);
                }
            }

            foreach (Enemy enemyColorGreen in _enemies)
            {
                if (enemyColorGreen.Color == Color.green)
                {
                    _enemiesColorGreen.Add(enemyColorGreen);
                }
            }

            foreach (Enemy enemyHealth in _enemies)
            {
                if (enemyHealth.Health < 20 && enemyHealth.Color == Color.green)
                {
                    _enemiesColorGreenHealth.Add(enemyHealth);
                }
            }

        }
    }
}

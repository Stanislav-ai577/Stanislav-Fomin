using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(UnitFabric))]

public class UnitSpawner : MonoBehaviour
{
    private UnitFabric _fabric;
    private List<Unit> _units = new List<Unit>();
    private Coroutine _moveTick;

    private void Awake()
    {
        _fabric = GetComponent<UnitFabric>();
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            _units.Add(_fabric.CreateUnit(randomPosition, transform));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           _moveTick = StartCoroutine(MoveTick());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if(_moveTick != null)
            {
                StopCoroutine(_moveTick);
                _moveTick = null;
            }
        }
    }

    private IEnumerator MoveTick()
    {
        foreach(Unit unit in _units)
        {
            yield return new WaitForSeconds(0.5f);
            unit.Move(Vector3.forward);
        }
    }
}

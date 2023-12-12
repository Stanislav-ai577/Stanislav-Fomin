using System.Collections;
using System.Collections.Generic;
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
            _moveTick = StartCoroutine(MoveBackTick());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _moveTick = StartCoroutine(MoveRightTick());
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _moveTick = StartCoroutine(MoveLeftTick());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_moveTick != null)
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
            yield return new WaitForSeconds(0.1f);
            unit.Move(Vector3.forward);
            unit.ChangeColor();
        }
    }

    private IEnumerator MoveBackTick()
    {
        foreach (Unit unit in _units)
        {
            yield return new WaitForSeconds(0.1f);
            unit.MoveBack(Vector3.forward);
            unit.ChangeColor();
        }
    }

    private IEnumerator MoveRightTick()
    {
        foreach (Unit unit in _units)
        {
            yield return new WaitForSeconds(0.1f);
            unit.MoveBack(-Vector3.right);
            unit.ChangeColor();
        }
    }

    private IEnumerator MoveLeftTick()
    {
        foreach (Unit unit in _units)
        {
            yield return new WaitForSeconds(0.1f);
            unit.MoveBack(-Vector3.left);
            unit.ChangeColor();
        }
    }
}

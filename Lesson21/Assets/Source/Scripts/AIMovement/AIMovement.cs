using System;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class AIMovement : MonoBehaviour
{
    private NavMeshAgent _player;

    private void Awake()
    {
        _player = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _player.SetDestination(hit.point);
            }
        }
    }
}

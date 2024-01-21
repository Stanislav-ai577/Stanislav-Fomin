using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public Action OnEnter;
    public Action OnExit;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ground>())
        {
            OnEnter?.Invoke();
        }
    } 
    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ground>())
        {
            OnExit?.Invoke();
        }
    }
}

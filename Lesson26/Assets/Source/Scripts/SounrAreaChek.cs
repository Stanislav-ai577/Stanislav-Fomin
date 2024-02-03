using System;
using UnityEngine;

public class SounrAreaChek : MonoBehaviour
{
    public Action OnEnter;
    public Action OnExit;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SoundArea>())
        {
            OnEnter?.Invoke();
        }
    } 
    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SoundArea>())
        {
            OnExit?.Invoke();
        }
    }
}

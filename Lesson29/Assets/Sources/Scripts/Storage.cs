using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [field: SerializeField] public List<Resource> ResourcesStorage = new List<Resource>();
    [SerializeField] private Resource _resource;

    private void Start()
    {
       
    }

   
}

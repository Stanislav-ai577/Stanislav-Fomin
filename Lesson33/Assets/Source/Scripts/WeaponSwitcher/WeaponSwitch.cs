using System;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [field: Header("Reference")] 
    [field:SerializeField] public GameObject CubeGun { get; private set; }
    [field:SerializeField] public GameObject SphereGun { get; private set; }
    [field:SerializeField] public GameObject CylinderGun { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectCubeGun();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSphereGun();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectCylinderGun();
        }
    }
    
    private void SelectCubeGun()
    {
        CubeGun.SetActive(true);
        SphereGun.SetActive(false);
        CylinderGun.SetActive(false);
    }
    
    private void SelectSphereGun()
    {
        CubeGun.SetActive(false);
        SphereGun.SetActive(true);
        CylinderGun.SetActive(false);
    }
    
    private void SelectCylinderGun()
    {
        CubeGun.SetActive(false);
        SphereGun.SetActive(false);
        CylinderGun.SetActive(true);
    }
}

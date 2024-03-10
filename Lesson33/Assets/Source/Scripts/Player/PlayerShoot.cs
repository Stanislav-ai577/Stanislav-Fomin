using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Reference")] 
    [SerializeField] private WeaponSwitch _weaponSwitch;
    [SerializeField] private CubeGun _cubeGun;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _weaponSwitch.CubeGun.activeSelf)
        {
            _cubeGun.Shoot();
        }
    }
}

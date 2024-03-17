using System;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    private IWeapon _currentWeapon;
    
    [field: SerializeField] public CubeGun CubeGun { get; private set; }
    [field: SerializeField] public SphereGun SphereGun { get; private set; }
    [field: SerializeField] public CylinderGun CylinderGun { get; private set; }

    public void ChangeWeapon(IWeapon newWeapon)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.RemoveWeapon();
        }

        _currentWeapon = newWeapon;
        _currentWeapon.TakeWeapon();
    }

    public void WeaponShoot()
    {
        if (_currentWeapon == null)
        {
            throw new ArgumentException("Available weapon is not selected.");
        }
        _currentWeapon.Shoot();
    }
}

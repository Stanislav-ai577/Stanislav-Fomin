using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private WeaponControl _weaponControl;
    private CubeGun _cubeGun;
    private CylinderGun _cylinderGun;
    private SphereGun _sphereGun;

    private void Start()
    {
        _cubeGun = _weaponControl.CubeGun;
        _sphereGun = _weaponControl.SphereGun;
        _cylinderGun = _weaponControl.CylinderGun;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _weaponControl.ChangeWeapon(_cubeGun);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _weaponControl.ChangeWeapon(_cylinderGun);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _weaponControl.ChangeWeapon(_sphereGun);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _weaponControl.WeaponShoot();
        }
    }
}

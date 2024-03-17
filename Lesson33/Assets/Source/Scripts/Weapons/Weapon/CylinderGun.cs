using UnityEngine;

public class CylinderGun : Weapon
{
    [SerializeField] private Ammo _ammo;
    [SerializeField] private Transform _spawnPointCylinderAmmo;
    [SerializeField] private float _forceShot;

    private void Start()
    {
        _ammo = Resources.Load<Ammo>("Ammo/CylinderAmmo");
    }

    public override void Shoot()
    {
        Ammo instantiate = Instantiate(_ammo, _spawnPointCylinderAmmo.position, Quaternion.identity,transform);
        instantiate.DirectionShot(_spawnPointCylinderAmmo.transform.forward, _forceShot);
    }

    public override void TakeWeapon()
    {
       gameObject.SetActive(true);
    }

    public override void RemoveWeapon()
    {
        gameObject.SetActive(false);
    }
}

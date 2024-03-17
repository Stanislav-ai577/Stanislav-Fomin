using UnityEngine;

public class SphereGun : Weapon
{
    [SerializeField] private Ammo _ammo;
    [SerializeField] private Transform _spawnPointSphereAmmo;
    [SerializeField] private float _forceshot;

    private void Start()
    {
        _ammo = Resources.Load<Ammo>("Ammo/SphereAmmo");
    }


    public override void Shoot()
    {
        Ammo instantiate = Instantiate(_ammo, _spawnPointSphereAmmo.position, Quaternion.identity,transform);
        instantiate.DirectionShot(_spawnPointSphereAmmo.transform.forward, _forceshot);
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

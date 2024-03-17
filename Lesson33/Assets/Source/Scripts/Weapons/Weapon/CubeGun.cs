using UnityEngine;

public class CubeGun : Weapon
{
    [SerializeField] private Ammo _ammo;
    [SerializeField] private Transform _spawnPointCubeAmmo;
    [SerializeField] private float _forceShot;

    private void Start()
    {
        _ammo = Resources.Load<Ammo>("Ammo/CubeAmmo");
    }

    public override void Shoot()
    {
       Ammo instantiate = Instantiate(_ammo, _spawnPointCubeAmmo.position, Quaternion.identity,transform);
       instantiate.DirectionShot(_spawnPointCubeAmmo.transform.forward, _forceShot);

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

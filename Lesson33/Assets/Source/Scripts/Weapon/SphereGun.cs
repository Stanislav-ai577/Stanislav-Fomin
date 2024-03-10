using UnityEngine;

public class SphereGun : CubeGun
{
    [Header("Reference")] 
    [SerializeField] private BulletFly _sphereBullet;
    [SerializeField] private Transform _spawnPointBullet;

    private void Awake()
    {
        _sphereBullet = Resources.Load<BulletFly>("Bullet/SphereBullet");
    }
    
    public override void Shoot()
    { 
        BulletFly bulletFly = Instantiate(_sphereBullet, _spawnPointBullet.position, Quaternion.identity);
        bulletFly.FlyBullet(_spawnPointBullet.transform.forward);
    }
}

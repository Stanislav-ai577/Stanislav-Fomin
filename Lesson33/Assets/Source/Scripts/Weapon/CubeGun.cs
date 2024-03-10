using UnityEngine;

public class CubeGun : MonoBehaviour
{
    [Header("Reference")] 
    [SerializeField] private BulletFly _cubeBullet;
    [SerializeField] private Transform _spawnPointBullet;

    private void Awake()
    {
        _cubeBullet = Resources.Load<BulletFly>("Bullet/CubeBullet");
    }
    
    public virtual void Shoot()
    { 
      BulletFly bulletFly = Instantiate(_cubeBullet, _spawnPointBullet.position, Quaternion.identity);
      bulletFly.FlyBullet(_spawnPointBullet.transform.forward);
    }
}

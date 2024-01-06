using System.Collections;
using UnityEngine;

public class CannonLvl2 : CannonLvl1
{
    [SerializeField] private float _delayBetweenShoot;
    
    public override void Shoot()
    {
        StartCoroutine(DoubleShooTick());
    }

    private void DoubleShoot()
    {
        if (Ammo == 0)
        {
            return;
        }
        
        Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballCreated.Fly(_spawnPoint.transform.forward, 50);
        Ammo--;
    }
    
    private IEnumerator DoubleShooTick()
    {
        DoubleShoot();
        yield return new WaitForSeconds(_delayBetweenShoot);
        DoubleShoot();
        StartCoroutine(Delay());
    }
}

using System.Collections;
using UnityEngine;

public class CannonVeryBig : Cannon
{
    [SerializeField] private float _delayBetWeenShoot;

    public override void Shoot()
    {
        StartCoroutine(DoubleShooTick());
    }

    public void DoubleShoot()
    {
        if (Ammo == 0)
            return;
        Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballCreated.Fly(_spawnPoint.transform.forward, 50);
        Ammo--;
    }

    private IEnumerator DoubleShooTick()
    {
        DoubleShoot();
        yield return new WaitForSeconds(_delayBetWeenShoot);
        DoubleShoot();
        yield return new WaitForSeconds(_delayBetWeenShoot);
        DoubleShoot();
        StartCoroutine(Delay());
    }
}

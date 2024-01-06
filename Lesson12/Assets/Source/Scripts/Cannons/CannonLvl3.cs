using System.Collections;
using UnityEngine;

public class CannonLvl3 : CannonLvl1
{
    [SerializeField] private float _delayBetweenShoot;
    
    public override void Shoot()
    {
        StartCoroutine(TriplShooTick());
    }

    private void TripleShooTick()
    {
        if (Ammo == 0)
        {
            return;
        }
        
        Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballCreated.Fly(_spawnPoint.transform.forward, 50);
        Ammo--;
    }
    
    private IEnumerator TriplShooTick()
    {
        TripleShooTick();
        yield return new WaitForSeconds(_delayBetweenShoot);
        TripleShooTick();
        yield return new WaitForSeconds(_delayBetweenShoot);
        TripleShooTick();
        StartCoroutine(Delay());
    }
}

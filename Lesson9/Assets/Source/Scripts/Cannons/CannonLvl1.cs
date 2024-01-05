using System.Collections;
using UnityEngine;

public class CannonLvl1 : MonoBehaviour
{
   [SerializeField] private protected Ball _ball;
   [SerializeField] private protected Transform _spawnPoint;
   [SerializeField] private protected float _delay;
   [SerializeField] private protected int _maxAmmo;
   [SerializeField] private protected float _reloadDelay;
   [field: SerializeField] public bool CanShoot { get; private set; }
   [field: SerializeField] public int Ammo { get; private protected set; }

   public virtual void Shoot()
   {
       Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
       ballCreated.Fly(_spawnPoint.transform.forward, 50);
       Ammo--;
       StartCoroutine(Delay());
   }

   public void Reload()
   {
       CanShoot = false;
       StartCoroutine(ReloadTick());
   }
   
   private protected IEnumerator Delay()
   {
       yield return new WaitForSeconds(_delay);
       CanShoot = true;
   }

   private IEnumerator ReloadTick()
   {
       yield return new WaitForSeconds(_reloadDelay);
       Ammo = _maxAmmo;
       CanShoot = true;
   }
}

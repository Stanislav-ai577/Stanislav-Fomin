using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   [SerializeField] private Ball _ball;
   [SerializeField] private Transform _spawnPoint;
   [SerializeField] private float _shootDelay;
   [SerializeField] private float _delay;
   [SerializeField] private float _countBall;
   [SerializeField] private float _reloadDelay;
   [SerializeField] private bool _canShoot;
   [SerializeField] private KeyCode _reload;
   
   
   
   
   
   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Space) && _canShoot == true && _countBall > 0)
       {
           StartCoroutine(ShooTick());
       }
       if (Input.GetKeyDown(_reload) && _countBall == 0)
       {
           _canShoot = false;
           StartCoroutine(ReloadTick());
       }
   }

   private void CreateBall()
   {
       _canShoot = false;
       _countBall--;
       Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
       ballCreated.Fly(_spawnPoint.transform.forward, 50);
       StartCoroutine(Delay());
   }

   private IEnumerator ShooTick()
   {
       yield return new WaitForSeconds(_shootDelay);
       CreateBall();
   }
   
   private IEnumerator Delay()
   {
       yield return new WaitForSeconds(_delay);
       _canShoot = true;
   }
   
   private IEnumerator ReloadTick()
   {
       yield return new WaitForSeconds(_reloadDelay);
       _countBall += 5;
       _canShoot = true;
   }
}

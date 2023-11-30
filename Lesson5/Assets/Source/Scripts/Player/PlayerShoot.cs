using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private bool _canShoot;
    [SerializeField] private float _delay;
    [SerializeField] private int _countBall;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canShoot == true && _countBall > 0)
        {
            CreateBall();
            _countBall--;
            
            if(_countBall == 0)
            {
                _canShoot = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.R) && _countBall == 0 && _canShoot == false)
        {
            StartCoroutine(DelayReload());
        }
    }

    private void CreateBall()
    {
        Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballCreated.Fly(_spawnPoint.transform.forward, 50);
    }

    private IEnumerator DelayReload()
    {
        yield return new WaitForSeconds(_delay);
        _countBall += 10;
        _canShoot = true;
    }
}

using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] public float _ammoCounter;   
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _reloaddelay;
 
    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) && _ammoCounter > 0)
            { 
                StartCoroutine(ShooTick());
            }
            if(Input.GetKey(KeyCode.R) && _ammoCounter == 0)
            {
                StartCoroutine(ReloadDelay());      
            }
    }

    private IEnumerator ShooTick()
    {
        yield return new WaitForSeconds(_shootDelay);
        CreateBall();
        _ammoCounter--;
    }

    private void CreateBall()
    {
        Ball ballcreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballcreated.Fly(_spawnPoint.transform.forward, 50); 
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_shootDelay);
    }

    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(_reloaddelay);
        _ammoCounter = 10;
    }
}

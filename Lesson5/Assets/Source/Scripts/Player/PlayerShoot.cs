using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _dilay;
    [SerializeField] private float _reloadDilay;
    [SerializeField] private float _countMissil;

    private void Update()
    {

            if (Input.GetKeyDown(KeyCode.Space) && _countMissil >= 1)
            {
                
                StartCoroutine(ShooTick());

            }
            else
            {

                if (Input.GetKeyDown(KeyCode.R) && _countMissil == 0 & _countMissil <= 10)
                {
                    StartCoroutine(ReloadTick());
                }

            }

    }

    private void CreateBall()
    { 

        Ball ballCreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballCreated.Fly(_spawnPoint.transform.forward, 50);

    }

    private IEnumerator ShooTick()
    {

        yield return new WaitForSeconds(_dilay);
        _countMissil -= 1;
        CreateBall();

    }

    private IEnumerator ReloadTick()
    {

        yield return new WaitForSeconds(_reloadDilay);
        _countMissil += 10;

    }

}

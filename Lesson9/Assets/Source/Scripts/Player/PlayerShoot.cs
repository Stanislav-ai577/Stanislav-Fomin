using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Cannon _currentCannon;
    [SerializeField] private Cannon _cannonLvl1;
    [SerializeField] private Cannon _cannonLvl2;
    [SerializeField] private Cannon _cannonLvl3;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && _currentCannon.CanShoot && _currentCannon.Ammo > 0)
        {
            _currentCannon.Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R) )
        {
            _currentCannon.Reload();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _cannonLvl1.gameObject.SetActive(true);
            _cannonLvl2.gameObject.SetActive(false);
            _cannonLvl3.gameObject.SetActive(false);
            _currentCannon = _cannonLvl1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _cannonLvl1.gameObject.SetActive(false);
            _cannonLvl2.gameObject.SetActive(true);
            _cannonLvl3.gameObject.SetActive(false);
            _currentCannon = _cannonLvl2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _cannonLvl1.gameObject.SetActive(false);
            _cannonLvl2.gameObject.SetActive(false);
            _cannonLvl3.gameObject.SetActive(true);
            _currentCannon = _cannonLvl3;
        }
    }
}

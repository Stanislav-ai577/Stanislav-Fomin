using System.Collections;
using UnityEngine;

public class SlingShootAmmo : MonoBehaviour
{
    [SerializeField] private ShootRubber _point;
    [SerializeField] private BirdsFactory _factory;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxAmmo;
    private float _currenAmmo;
    [SerializeField] private Transform _rubberPosition;
    [SerializeField] private Transform _startPosition;

    private void Awake()
    {
        _currenAmmo = _maxAmmo;
        NextBird();
        _point.OnRealeasesShoot += NextBird;
    }

    private void NextBird()
    {
        if (_currenAmmo <= 0)
            return;
        _currenAmmo--;
        StartCoroutine(ReloadDelay());
    }

    private void CreateBird()
    {
        Birds newBird = _factory.CreateBird(_startPosition.position);
        newBird.Setup(_rubberPosition, _startPosition);
        _point.UpdateBird(newBird);
    }

    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(_delay);
        CreateBird();
    }
}

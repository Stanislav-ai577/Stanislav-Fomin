using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TileSpawner _tileSpawner;
    [SerializeField] private Transform _transform;

    private void Start()
    {
        CreatedPlayer();
        CreatedTileSpawner();
    }

    private void CreatedTileSpawner()
    {
       TileSpawner tileSpawner = Instantiate(_tileSpawner, transform.position, Quaternion.identity, transform);
    }

    private void CreatedPlayer()
    {
        Player player = Instantiate(_player, transform.position, Quaternion.identity, transform);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private List<TileMovement> tile = new List<TileMovement>();
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _tileLength;
    [SerializeField] private float _tilePositionLength;
    private TileMovement _road;

    private void Start()
    {
        SpawnFirstTile();
    }
    
    private void SpawnFirstTile()
    {
        Vector3 position = new Vector3(0, -1f, _playerPosition.position.z + _tilePositionLength);
        _road = Instantiate(tile[UnityEngine.Random.Range(0, tile.Count)], position, Quaternion.identity, transform);
    }
    
    public void SpawnRoad()
    {
        Vector3 position = new Vector3(0, -1f, transform.position.z + _tileLength);
        _road = Instantiate(tile[UnityEngine.Random.Range(0, tile.Count - 1)], position, Quaternion.identity, transform);
    }
}

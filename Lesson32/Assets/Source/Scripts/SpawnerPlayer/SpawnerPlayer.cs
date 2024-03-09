using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    public Vector3 TargetPlayerPosition { get; private set; }
    

    private void Awake()
    {
        _player = Resources.Load<Player>("Player/Player");
    }

    private void OnEnable()
    {
        PlayerHealth.PlayerDie += PlayerSpawner;
    }
    private void OnDisable()
    {
        PlayerHealth.PlayerDie -= PlayerSpawner;
    }
    

    private void Start()
    {
        PlayerSpawner();
    }

    private void PlayerSpawner()
    {
        Player instance = Instantiate(_player, transform.position, Quaternion.identity);
        TargetPlayerPosition = instance.transform.position;
    }
}

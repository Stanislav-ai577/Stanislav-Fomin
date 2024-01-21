using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailWindow : MonoBehaviour, IEntryPointSetupPlayer
{
    [SerializeField] private GameObject _window;
    [SerializeField] private Button _restart;
    private IEntryPointSetupPlayer _entryPointSetupPlayerImplementation;

    private void Awake()
    {
        _restart.onClick.AddListener(Restart);
    }

    public void Open() => _window.SetActive(true);
    
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    public void Setup(PlayerMovement player)
    {
        player.GetComponent<PlayerHealth>().OnDie += Open;
    }
}

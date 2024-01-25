using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinWindow : MonoBehaviour,IEntryPointSetupTimer
{
    [SerializeField] private GameObject _window;
    [SerializeField] private Button _restart;

    private void Awake()
    {
        _restart.onClick.AddListener(Restart);
    }

    public void Open() => _window.SetActive(true);
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void Setup(Timer timer)
    {
        timer.OnEnd += Open;
    }
}

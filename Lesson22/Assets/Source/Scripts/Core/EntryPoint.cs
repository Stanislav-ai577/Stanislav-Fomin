using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Space(20), Header("Text"), SerializeField]
    private Transform _canvas;
    
    [Space(20),Header("Starts Point"), SerializeField] 
    private Transform _playerStartPoint;
    
    [SerializeField] private List<Transform> _enemyStartPointRed;
    [SerializeField] private List<Transform> _enemyStartPointBlue;

    private List<IEntryPointSetupPlayer> _setupPlayers = new List<IEntryPointSetupPlayer>();
    private List<IEntryPointSetupTimer> _setupTimers = new List<IEntryPointSetupTimer>();
    private EnemyRed _basicEnemyRed;
    private EnemyBlue _basicEnemyBlue;
    private PlayerMovement _player;
    private PlayerMovement _playerCreated;
    private Timer _timer;
    private Timer _timerCreated;
    private WinWindow _winWindow;
    private FailWindow _failWindow;
    
    private void Awake()
    {
        _basicEnemyRed = Resources.Load<EnemyRed>("EnemyRed");
        _basicEnemyBlue = Resources.Load<EnemyBlue>("EnemyBlue");
        _player = Resources.Load<PlayerMovement>("Player");
        _timer = Resources.Load<Timer>("Timer");
        _winWindow = Resources.Load<WinWindow>("WinWindow");
        _failWindow = Resources.Load<FailWindow>("FailWindow");
        CreateUI();
        CreatePlayer();
        CreateEnemyRed();
        CreateEnemyBlue();
        Setup();
    }

    private void CreateUI()
    {
       _timerCreated = Instantiate(_timer, _timer.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas);
       _timerCreated.GetComponent<RectTransform>().localPosition = _timer.GetComponent<RectTransform>().localPosition;
       
       WinWindow winWindowCreated = Instantiate(_winWindow, _winWindow.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas);
       winWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
       _setupTimers.Add(winWindowCreated);
       
       FailWindow failWindowCreated = Instantiate(_failWindow, _failWindow.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas);
       failWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
       _failWindow.GetComponent<RectTransform>().localPosition = Vector3.zero;
       _setupPlayers.Add(failWindowCreated);
    }
    
    private void CreatePlayer()
    {
       _playerCreated = Instantiate(_player, _playerStartPoint.position, Quaternion.identity);
    }

    private void CreateEnemyRed()
    {
        foreach (Transform point in _enemyStartPointRed)
        {
            IEntryPointSetupPlayer enemyBlueRed = Instantiate(_basicEnemyRed, point.position, Quaternion.identity);
            _setupPlayers.Add(enemyBlueRed);
        }
    }

    private void CreateEnemyBlue()
    {
        foreach (Transform point in _enemyStartPointBlue)
        {
            IEntryPointSetupPlayer enemyBlue = Instantiate(_basicEnemyBlue, point.position, Quaternion.identity);
            _setupPlayers.Add(enemyBlue);
        }
    }

    private void Setup()
    {
        foreach (IEntryPointSetupPlayer setupPlayer in _setupPlayers)
        {
            setupPlayer.Setup(_playerCreated);
        }
        
        foreach (IEntryPointSetupTimer setupTimer in _setupTimers)
        {
            setupTimer.Setup(_timerCreated);
        }
    }
}

public interface IEntryPointSetupPlayer
{
    public void Setup(PlayerMovement player);
}

public interface IEntryPointSetupTimer
{
    public void Setup(Timer timer);
}

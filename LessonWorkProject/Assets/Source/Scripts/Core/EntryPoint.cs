using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("Timer"), Space(5)] [SerializeField]
    private Transform _canvas;
    
    [Header("Starts Points Slime"), Space(5)]
    [SerializeField] private Transform _playerStartsPoint;
    
    [SerializeField] private List<Transform> _enemySlimeStartsPoints;
    [SerializeField] private List<Transform> _enemyTurtleStartsPoints;
    
    private Enemy _enemySlime;
    private Enemy _enemyTurtle;
    private PlayerMovement _player;
    private PlayerMovement _playerCreated;
    private Timer _timer;
    private Timer _timerCreated;
    private WinWindow _winWindow;
    private FailWindow _failWindow;

    private Coroutine _respawnEnemyTick;
    
    private readonly List<IEntryPointSetupPlayer> _setupPlayers = new List<IEntryPointSetupPlayer>(); // что делает эта строка :?
    private readonly List<IEntryPointSetupTimer> _setupTimer = new List<IEntryPointSetupTimer>(); // что делает эта строка :?

    private void Awake()
    {
        _enemySlime = Resources.Load<Enemy>("Slime");
        _enemyTurtle = Resources.Load<Enemy>("Turtle");
        _player = Resources.Load<PlayerMovement>("YBot");
        //_player = Resources.Load<PlayerMovement>("YBot");
        _timer = Resources.Load<Timer>("Timer");
        _winWindow = Resources.Load<WinWindow>("WinWindow");
        _failWindow = Resources.Load<FailWindow>("FailWindow");
        _respawnEnemyTick = StartCoroutine(RespawnEnemyTick());
        CreateUI();
        CreatedPlayer();
        CreatedEnemiesSlime();
        CreatedEnemiesTurtle();
        Setup();
    }

    private void CreateUI()
    {
       _timerCreated = Instantiate(_timer, _timer.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas);
       _timerCreated.GetComponent<RectTransform>().localPosition = _timer.GetComponent<RectTransform>().localPosition;
       _timerCreated.OnEnd += () => StopCoroutine(_respawnEnemyTick);

       WinWindow winWindowCreated = Instantiate(_winWindow, _winWindow.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas);
       winWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
       _setupTimer.Add(winWindowCreated);
       
       FailWindow failWindowCreated = Instantiate(_failWindow, _failWindow.GetComponent<RectTransform>().localPosition, Quaternion.identity, _canvas);
       failWindowCreated.GetComponent<RectTransform>().localPosition = Vector3.zero;
       _setupPlayers.Add(failWindowCreated);
    }

    private void CreatedPlayer()
    {
        _playerCreated = Instantiate(_player, _playerStartsPoint.position, Quaternion.identity);
    }

    private void CreatedEnemiesSlime()
    {
        foreach (Transform pointSlime in _enemySlimeStartsPoints)
        {
          IEntryPointSetupPlayer enemySlime = Instantiate(_enemySlime, pointSlime.position, Quaternion.identity);
          _setupPlayers.Add(enemySlime);
        }
    }

    private void CreatedEnemiesTurtle()
    {
        foreach (Transform pointTurtle in _enemyTurtleStartsPoints)
        {
            IEntryPointSetupPlayer enemyTurtle = Instantiate(_enemyTurtle, pointTurtle.position, Quaternion.identity);
            _setupPlayers.Add(enemyTurtle);
        }
    }

    private void Setup()
    {
        foreach (IEntryPointSetupPlayer setupPlayer in _setupPlayers)
        {
            setupPlayer.Setup(_playerCreated); //что делает эта строка :?
        }
        foreach (IEntryPointSetupTimer setupTimer in _setupTimer)
        {
            setupTimer.Setup(_timerCreated); //что делает эта строка :?
        }
    }

    private IEnumerator RespawnEnemyTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            CreatedEnemiesSlime();
            CreatedEnemiesTurtle();
            Setup();
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

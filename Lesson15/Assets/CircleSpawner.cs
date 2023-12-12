using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleFabrica))]
public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private CounterUI _counter;
    [SerializeField] private int _currentCount, _goalCount;
    [SerializeField] private float _delay;
    private CircleFabrica _fabrica;

    private void Awake()
    {
        _fabrica = GetComponent<CircleFabrica>();
        _counter.OnCountChange += CounterHandler;
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }

    private void RemoveCurrentCircle()
    {
        _currentCount--;
    }

    private void CheckCircleCount()
    {
        if(_currentCount >= _goalCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CounterHandler(int count)
    {
        if((count % 10) == 1)
        {
            _delay -= 0.1f;
        }
    }

    private void CreatedCircle() 
    {
        Circle circleCreated = null;
        _currentCount++;
        Vector3 randomPosition = new Vector3(Random.Range(-6, 6), Random.Range(-6, 6), 0);
        float chance = Random.Range(0, 100);
        if (chance < 30)
        {
            randomPosition += new Vector3(0, 0, 0.8f);
            circleCreated = _fabrica.CreateCircle(randomPosition).Setup(_counter);
        }
        if (chance >= 30 && chance <= 70)
        {
            randomPosition += new Vector3(0, 0, 0.7f);
            circleCreated = _fabrica.CreateMoveCircle(randomPosition).Setup(_counter);
        }
        if (chance > 70 && chance < 95)
        {
            randomPosition += new Vector3(0, 0, 1);
            circleCreated = _fabrica.CreateBadCircle(randomPosition).Setup(_counter);
            circleCreated.OnClick += RestartLevel;
            _currentCount--;
        }
        if (chance >= 95)
        {
            randomPosition += new Vector3(0, 0, 0.5f);
            circleCreated = _fabrica.CreateGoldCircle(randomPosition).Setup(_counter);
        }
        if (chance >= 80)
        {
            randomPosition += new Vector3(0, 0, 2);
            circleCreated = _fabrica.CreateBlackCircle(randomPosition).Setup(_counter);
        }
        circleCreated.OnDestroy += RemoveCurrentCircle;
        CheckCircleCount();
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return null;
            for(int i = _currentCount; _currentCount < _goalCount; i++)
            {
                yield return new WaitForSeconds(_delay);
                CreatedCircle();
            }
        }
    }
}

using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private protected int _count;
    [SerializeField] private protected TextMeshProUGUI _counter;
    [SerializeField] private protected GameObject _spawner;
    [SerializeField] public int CountScale {get; private set; }

    private void Awake()
    {
        CountScale = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>()) 
        {
            TargetsCounter();
        }
        TargetsSpawn();
    }

    public virtual void TargetsCounter()
    {
            _count++;
            _counter.text = "Score: " + _count.ToString();
            _spawner.transform.localScale += new Vector3(CountScale, CountScale, CountScale);
            Destroy(gameObject);
    }

    public virtual void TargetsSpawn()
    {
        Vector3 _randomSpwnPosition = new Vector3(Random.Range(-5, 5), Random.Range(7, 0), Random.Range(-10, 10));
        Instantiate(_spawner, _randomSpwnPosition, Quaternion.identity);
    }
}


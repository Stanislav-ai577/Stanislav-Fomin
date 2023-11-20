using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private int _countCube;
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private GameObject _spawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            _count++;
            _counter.text = "Score: " + _count.ToString();
            Destroy(collision.gameObject);
        }
            Vector3 _randomSpwnPosition = new Vector3(Random.Range(-5, 5), Random.Range(7, 0), Random.Range(-10, 10));
            Instantiate(_spawner, _randomSpwnPosition, Quaternion.identity);
    }
}


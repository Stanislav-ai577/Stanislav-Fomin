using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Targets : MonoBehaviour
{

    [SerializeField] private int _count;
    [SerializeField] TextMeshProUGUI _counter;
    [SerializeField] private GameObject _spawner;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<Ball>())
        {

            _count++;
            _counter.text = _count.ToString();
            Vector3 _randomSpwnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
            Instantiate(_spawner, _randomSpwnPosition, Quaternion.identity);
            Destroy(collision.gameObject);

        }

    }

}

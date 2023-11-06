using TMPro;
using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] private GameObject _spawner;
    [SerializeField] private int _spawnerCount;
    [SerializeField] private int _spawnTick;

    public void SpawnCoub()
    {

            Vector3 _randomSpwnPosition = new Vector3(Random.Range(-10, 11), Random.Range(11, -5), Random.Range(-10, 11));
            Instantiate(_spawner, _randomSpwnPosition, Quaternion.identity);
 
    }

    private IEnumerator SpawnTick()
    {

        yield return new WaitForSeconds(_spawnTick);
        SpawnCoub();

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<Ball>())
        {

            StartCoroutine(SpawnTick());
            Destroy(collision.gameObject);

        }

    }

}

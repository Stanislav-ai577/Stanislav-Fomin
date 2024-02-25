using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public List<GameObject> Enemy = new List<GameObject>();
    [SerializeField] private GameObject _player;
  
    private void Update()
    {
        DistanceChecker();
    }

    private void DistanceChecker()
    {
        GameObject removeObject = null;
        float minimalDistance = Mathf.Infinity;

        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemy[i] == null)
            {
                Enemy.RemoveAt(i);
                i--;
                continue;
            }

            float distance = Vector3.Distance(_player.transform.position, Enemy[i].transform.position);

            if (distance < minimalDistance)
            {
                minimalDistance = distance;
                removeObject = Enemy[i];
            }
        }

        if (removeObject != null && minimalDistance <= 3.0f)
        {
            Destroy(removeObject);
            Enemy.Remove(removeObject);
        }
    }
}

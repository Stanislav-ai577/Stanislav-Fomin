using UnityEngine;

public class SpawnLoop : MonoBehaviour
{
    [SerializeField] private int _count;

    private void Start()
    {
        for(int i = 0; i < _count; i++)
        {
            Debug.Log("Hello" + i);
        }
    }
}

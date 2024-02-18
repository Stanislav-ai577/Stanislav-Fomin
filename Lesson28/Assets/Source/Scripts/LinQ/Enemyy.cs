using UnityEngine;

public class Enemyy : MonoBehaviour
{
    [field: SerializeField] public int Id { get; private set; }

    private void Awake()
    {
        if (Id == 0)
        {
            Id = Random.Range(0, 100000);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

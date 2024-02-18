using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public Color Color;
    
    private void Awake()
    {
        Health = 100f;
    }
    
    public void EnemyColor(Color color)
    {
        Color = color;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}

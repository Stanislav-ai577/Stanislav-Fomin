using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int speed;

    public abstract void Move();
    
    public abstract void TakeDamage(int damage);

    public abstract void SetupPosition(Transform player);

    public abstract void Die();

}

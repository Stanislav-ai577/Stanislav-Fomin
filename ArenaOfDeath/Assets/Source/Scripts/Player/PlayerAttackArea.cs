using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
   [SerializeField] private PlayerAttack _playerAttack;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamage damage))
            damage.TakeDamage(_playerAttack.Damage);
    }
}

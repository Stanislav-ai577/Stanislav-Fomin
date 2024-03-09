using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
   [SerializeField] private int _enemyDamage;
   private int _addDamage;

   private void Awake()
   {
      _addDamage += 20;
      _enemyDamage = 10;
   }

   private void OnEnable()
   {
      PlayerHealth.PlayerDie += DamageUp;
   }

   private void OnDisable()
   {
      PlayerHealth.PlayerDie -= DamageUp;
   }

   private void DamageUp()
   {
      _enemyDamage += _addDamage;
   }
   
   private void OnCollisionEnter(Collision collision)
   {
      PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
      
      if (playerHealth != null)
      {
         playerHealth.TakeDamage(_enemyDamage);
      }
   }
}

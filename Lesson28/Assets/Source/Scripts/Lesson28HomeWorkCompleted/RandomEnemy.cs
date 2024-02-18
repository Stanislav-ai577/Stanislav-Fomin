using UnityEngine;
using Random = UnityEngine.Random;

public enum EnemyType
{
    Zombie,
    Skeleton,
    Alien,
}

public class RandomEnemy : MonoBehaviour
{ 
    [SerializeField] private EnemyType[] _allenemyType = { EnemyType.Alien, EnemyType.Skeleton, EnemyType.Zombie }; 
   [SerializeField] private EnemyType Type;
   [SerializeField] private int _health;
   [SerializeField] private float _speed;
   
   private void Awake()
   {
       RandomHealth();
       RandomSpeed();
       RandomEnemyType();
   }

   public void RandomHealth()
   {
       _health = Random.Range(0, 100);
   }

   public void RandomSpeed()
   {
       _speed = Random.Range(0, 20);
   }

   public void RandomEnemyType()
   {
       EnemyType RandomTypeEnemies = _allenemyType[Random.Range(0, _allenemyType.Length)];
       Type = RandomTypeEnemies;
   }
}

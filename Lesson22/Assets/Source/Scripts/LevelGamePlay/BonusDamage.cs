using UnityEngine;

public class BonusDamage : MonoBehaviour
{
    [field: SerializeField] public float TimeBonusDamage { get; private set; }

    public void Destroy() => Destroy(gameObject);
}

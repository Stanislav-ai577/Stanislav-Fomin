using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ammo : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [field: SerializeField] public int Damage { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void DirectionShot(Vector3 direction, float force)
    {
        _rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Minion>() || other.gameObject.GetComponent<Giant>() || other.gameObject.GetComponent<Colossus>())
        {
            Destroy(gameObject);
        }
    }
}

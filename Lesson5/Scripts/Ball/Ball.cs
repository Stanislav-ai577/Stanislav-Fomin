using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Rigidbody _rigidbody;

    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        
    }

    public void Fly(Vector3 direction, float force)
    {

        _rigidbody.AddForce(direction * force, ForceMode.Impulse);

    }

}

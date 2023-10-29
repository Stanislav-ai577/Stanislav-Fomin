using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Rigidbody _forceRigidbody;
    [SerializeField] private Mass _mass;
    [SerializeField] private float _speed;
    private float _countKill;
    [SerializeField] private float _force;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Debug.Log("Now my mass has a value:" + " " + _mass.Amount);

    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            _rigidbody.velocity = new Vector3(0, 0, _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(0, 0, -_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(-_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector3(_speed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale = new Vector3(_mass.Amount, _mass.Amount, _mass.Amount);

        if (collision.gameObject.GetComponent<Mass>())
        {
            if (_mass.Amount > collision.gameObject.GetComponent<Mass>().Amount)
            {
                _mass.Amount += collision.gameObject.GetComponent<Mass>().Amount;
                transform.localScale = new Vector3(_mass.Amount, _mass.Amount, _mass.Amount);
                Destroy(collision.gameObject);
                _countKill++;
                Debug.Log($"I ate enemy" + " " + _countKill + " " + "and became the masses:" + " " + _mass.Amount);
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("Game over!" + " " + "Go swing the bull.");
            }
        }

        Vector3 normalVector = (collision.transform.position + transform.position).normalized;
        _forceRigidbody.AddForce(normalVector * _force, ForceMode.Impulse);

    }
}

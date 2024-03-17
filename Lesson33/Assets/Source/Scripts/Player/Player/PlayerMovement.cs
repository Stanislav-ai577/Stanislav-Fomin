using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        CameraRotate();
        Movement();
    }

    private void CameraRotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _speedRotate;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }
    
    private void Movement()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        direction *= _speed;

        Vector3 directionMove = transform.right * direction.x + transform.forward * direction.z;
        _rigidbody.velocity = new Vector3(directionMove.x, _rigidbody.velocity.y, directionMove.z);

        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
}

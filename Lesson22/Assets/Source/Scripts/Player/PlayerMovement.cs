using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private bool _isGround;
    private Rigidbody _rigidbody;
    private RaycastHit _raycastHit;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _groundChecker.OnEnter += SetGround;
        _groundChecker.OnExit += RemoveGround;
       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
    }

    private void Update()
    {
        RotateCamera();

        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }
    }

    private void SetGround()
    {
        _isGround = true;
    }
    
    private void RemoveGround()
    {
        _isGround = false;
    }
    
    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * _rotateSpeed;
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }
    
    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
    }

    private void Movement()
    {
        Vector3 inputMove = Vector3.zero;
        
        inputMove.x = Input.GetAxis("Horizontal");
        inputMove.z = Input.GetAxis("Vertical");

        inputMove *= _speed;

        Vector3 directionMove = transform.right * inputMove.x + transform.forward * inputMove.z;

        _rigidbody.velocity = new Vector3(directionMove.x, _rigidbody.velocity.y, directionMove.z);
    }
}

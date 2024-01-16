using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
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
    }

    private void Update()
    {
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
    
    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
    }

    private void Movement()
    {
        Vector3 directionMove = Vector3.zero;
        
        directionMove.x = Input.GetAxis("Horizontal");
        directionMove.z = Input.GetAxis("Vertical");

        directionMove *= _speed;

        _rigidbody.velocity = new Vector3(directionMove.x, _rigidbody.velocity.y, directionMove.z);
    }
}

using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotate;
    [SerializeField] private float _claimX, _claimY;

    [SerializeField] private float _speedCamera;
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _mouseRotate;
    private float _cameraX;
    private float _cameraY;

    [SerializeField] private bool _controlMode = true;

    private void Update()
    {
        if (_controlMode)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            _rotate += new Vector3(-vertical, horizontal, 0) * _speed;
            _rotate.x = Mathf.Clamp(_rotate.x, -_claimX, _claimX);
            _rotate.y = Mathf.Clamp(_rotate.y, -_claimY, _claimY);

            transform.rotation = Quaternion.Euler(_rotate);
        }
        else
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

            _cameraX -= mouseX;
            _cameraX = Mathf.Clamp(_cameraX, -_mouseRotate, _mouseRotate);

            _cameraY -= mouseY;
            _cameraY = Mathf.Clamp(_cameraY, -_mouseRotate, _mouseRotate);

            transform.localRotation = Quaternion.Euler(_cameraY, -_cameraX, 0f);

            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

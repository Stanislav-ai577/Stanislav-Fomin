using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotateRange;
    [SerializeField] private float _axisX, _axisY;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _rotateRange += new Vector3(-vertical,horizontal,0) * _speed;
        _rotateRange.x = Mathf.Clamp(_rotateRange.x, -_axisX, _axisX);
        _rotateRange.y = Mathf.Clamp(_rotateRange.y, -_axisY, _axisY);

        transform.rotation = Quaternion.Euler(_rotateRange);
    }
}

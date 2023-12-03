using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Vector3 _startPos;

    private void Awake()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(_startPos.x + Mathf.Sin(Time.time * 3), _startPos.y, _startPos.z);
    }
}

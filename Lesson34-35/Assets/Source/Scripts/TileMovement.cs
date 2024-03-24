using System;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Movement();
        TileDestroy();
    }

    private void Movement()
    {
        transform.Translate(-transform.forward * (_speed * Time.deltaTime));
    }
    
    private void TileDestroy()
    {
        if (transform.position.z < -50f)
        {
            Destroy(gameObject);
        }
    }
}

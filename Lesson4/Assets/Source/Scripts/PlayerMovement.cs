using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private AmountMass _mass;
    [SerializeField] private BackJumpAmount _backJumpMass;
    [SerializeField] private int _countEnemy;
    [SerializeField] private float _backHumpForce;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = new Vector3(0,0,_speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(0,0,-_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(-_speed,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector3(_speed,0,0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TransformScale();
        
        if (collision.gameObject.GetComponent<AmountMass>())
        {
            if (_mass.Mass > collision.gameObject.GetComponent<AmountMass>().Mass)
            {
                _mass.Mass += collision.gameObject.GetComponent<AmountMass>().Mass;
                transform.localScale = new Vector3(_mass.Mass, _mass.Mass, _mass.Mass);
                _countEnemy += 1;
                Debug.Log("Я сьел " + _countEnemy + "-го врага" + " и стал массы " + _mass.Mass);
                Destroy(collision.gameObject);
            }
            else
            {
                if (_mass.Mass < collision.gameObject.GetComponent<AmountMass>().Mass)
                {
                    Debug.Log("Иди качайся бычара!!");
                    Destroy(_mass.gameObject);
                }
            }
        }
        
        if (collision.gameObject.GetComponent<BackJumpAmount>())
        {
            if (_backJumpMass.BackJumpMass > collision.gameObject.GetComponent<BackJumpAmount>().BackJumpMass)
            {
               _backJumpMass.RigidbodyBackJump.AddForce(new Vector3(0,0,-_backHumpForce)); 
            }
        }
    }

    private void TransformScale()
    {
        transform.localScale = new Vector3(_mass.Mass,_mass.Mass,_mass.Mass);
    }
}

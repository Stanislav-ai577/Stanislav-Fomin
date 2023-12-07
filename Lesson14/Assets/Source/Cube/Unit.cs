using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]
public class Unit : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    private MeshRenderer _meshRenderer;
 
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Move(Vector3 directiob)
    {
        _rigidbody.AddForce(directiob * _speed, ForceMode.Impulse);
    }

    public void ChangeColor()
    {
        StartCoroutine(ChangeColorTick());
    }

    private IEnumerator ChangeColorTick()
    {
        yield return new WaitForSeconds(0.5f);
        _meshRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}

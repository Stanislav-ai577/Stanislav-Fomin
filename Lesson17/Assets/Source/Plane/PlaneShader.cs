using UnityEngine;

public class PlaneShader : MonoBehaviour
{
    [SerializeField] private Material _planeShader;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _planeShader.SetFloat("_Speed", 50);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _planeShader.SetFloat("_Speed", 1);
        }
    }
}

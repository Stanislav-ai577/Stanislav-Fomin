using UnityEngine;

public class PlayerEating : MonoBehaviour
{
    [SerializeField] private float _food;
    [SerializeField] private float _eat;
    [SerializeField] private float _hungry;
    [SerializeField] private float _ate;

    private void Start()
    {
        Debug.Log("hungry " + _hungry + " %");
        Debug.Log("food " + _food + " %");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerEat();
        }
    }

    private void PlayerEat()
    {
        _food -= _eat;
        _hungry -= _ate;
        Debug.Log("Food " + _food + " %");
        Debug.Log("I ate " + _hungry + " %");
    }
}

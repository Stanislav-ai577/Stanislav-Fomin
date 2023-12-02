using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private protected int _count;
    [SerializeField] private protected TextMeshProUGUI _counter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>()) 
        {
            TargetsCounter();
        }
    }

    private void TargetsCounter()
    {
            _count++;
            _counter.text = "Score: " + _count.ToString();
            Destroy(gameObject);
    }

    public void SetCounter(TextMeshProUGUI textMeshPro)
    {
        _counter = textMeshPro;
    }
}


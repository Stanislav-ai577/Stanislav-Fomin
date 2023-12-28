using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private CounterUI _counter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            Counter();
            Destroy(collision.gameObject);
        }
    }

    public void SetCounter(CounterUI counter)
    {
        _counter = counter;
    }

    private void Counter()
    {
        _counter.AddCount(1);
    }
}

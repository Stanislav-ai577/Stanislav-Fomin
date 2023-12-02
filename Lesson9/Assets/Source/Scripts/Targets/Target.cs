using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private protected int _count;
    [SerializeField] private protected TextMeshProUGUI _counter;
    [SerializeField] private protected Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public virtual void CreatedNewTarget(Vector3 position)
    {
        _transform.position = new Vector3(Random.Range(-15, 15), Random.Range(3, 12), Random.Range(5, 15));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            Counter();
            Destroy(collision.gameObject);
        }
    }

    public virtual void Counter()
    {
        _count++;
        _counter.text = "Score: " + _count.ToString();
    }

    public virtual void SetCounter(TextMeshProUGUI textMeshPro)
    {
        _counter = textMeshPro;
    }
}

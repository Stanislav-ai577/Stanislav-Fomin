using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void CreatedNewTarget(Vector3 position)
    {
        _transform.position = new Vector3(Random.Range(-15, 15), Random.Range(3, 9), Random.Range(3, 3));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            _count++;
            _counter.text = "Score: " + _count.ToString();
            Destroy(collision.gameObject);
        }
    }
}

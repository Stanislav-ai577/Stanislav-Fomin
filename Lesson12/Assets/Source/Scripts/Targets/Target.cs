using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    [SerializeField] private protected int _count;
    [SerializeField] private protected TextMeshProUGUI _textMeshPro;
    private protected CounterUI _counter;

    private void Awake()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            CollisionTarget();
            Destroy(collision.gameObject);
        }
    }

    public virtual void CollisionTarget()
    {
        Counter();
    }
    
    public virtual void SetCounter(CounterUI counter)
    {
        _counter = counter;
    }

    public virtual void Counter()
    {
        _counter.AddCount(1);
    }

    private void TransformScale()
    {
        transform.localScale = new Vector3(0f, 5f, 0f);
    }
}

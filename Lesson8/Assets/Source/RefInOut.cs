using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RefInOut : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    private void Awake()
    {
        if (TryGetComponent(out BoxCollider box))
        {
            box.enabled = false;
            Debug.Log("Нашли");
        }
        else
        {
            Debug.Log("Не нашли");
        }

        _rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(_rigidbody2D);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.Amount -= 10;
        }
    }

    private void Start()
    {
        int a = 10;
        Health health = new Health();
        
        DebugA(ref a);
        Debug.Log(a); 

        DebugD(in health);
        Debug.Log(health);
        
        CalculateAB(4,5, out int resultCalculate);
        Debug.Log(resultCalculate);
    }

    private void DebugA(ref int value)
    {
        value *= 2;
        Debug.Log(value.ToString());
    }
    
    private void DebugD(in Health value)
    {
        Debug.Log(value.ToString());
    }

    private void CalculateAB(int a, int b, out int result)
    {
        result = a + b;
    }
}

public class Health : MonoBehaviour
{
    public float Amount;
}


using System.Collections;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private int _count;
    private CounterUI _counter;

    public void SetCounter(CounterUI counter)
    {
        _counter = counter;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Birds>())
        {
            _counter.AddCount(1);
            StartCoroutine(DestroyTick());
        }
        
    }

    private IEnumerator DestroyTick()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

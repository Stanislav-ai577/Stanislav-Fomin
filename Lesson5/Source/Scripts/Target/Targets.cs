using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Targets : MonoBehaviour
{

    [SerializeField] private int _count;
    [SerializeField] TextMeshProUGUI _counter;
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<Ball>())
        {

            _count++;
            _counter.text = _count.ToString();
            Destroy(collision.gameObject);

        }

    }

}

using System.Collections;
using UnityEngine;


public class Factory : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private int _seconds;
    private int _secondsDone;
    
    

    private void Awake()
    {
        _resource = Resources.Load<Resource>("Resource");
        
    }

    private void Start()
    {
        StartCoroutine(SpawnTick());
    }

    public void CreateReource()
    { 
        Instantiate(_resource,transform.position, Quaternion.identity);
    }

    private IEnumerator SpawnTick()
    {
        while (_secondsDone < _seconds)
        {
            yield return new WaitForSeconds(1);
            _secondsDone++;
            CreateReource();
        }
        
    }
}

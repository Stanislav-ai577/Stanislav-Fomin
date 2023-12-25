using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _foodobj;
    private int _food, _eatFood;
    private float _dirt, _clean;

    void Start()
    {
        _food = 100;
        Debug.Log($"Amount of food on the plate " + _food);

        TakeEat(20, "I'm eating ", " There's food left ");
        TakeEat(30, "I'm eating ", " There's food left ");
        TakeEat(50, "I'm eating ", " There's food left ");
        Debug.Log("i'm full");

        _dirt = 0;
        _clean = 100;
        Debug.Log($"Clothes are dirty on " + _dirt + "% " + "Clothes are clean on " + _clean + "%");

        AddGettingClothesDirty(20);
        AddGettingClothesDirty(30);
        AddGettingClothesDirty(50);
        Debug.Log($"All the clothes are dirty" + "!");
    }

    private void Update()
    {
        addClothesDirty();
    }

    private void TakeEat(int yam, string iEat, string foodLeft) 
    {
        _food = _food - yam;
        _eatFood = yam;
        Debug.Log($"" + iEat + _eatFood + "%" + foodLeft + _food + "%");
    }


    private void AddGettingClothesDirty(int yami)
    {
        _dirt = _dirt + yami;
        _clean = _clean - yami;  
        Debug.Log($"I got dirty " +  _dirt + "% " + "clothes are clean on " + _clean + "%");
        
    }

    private void addClothesDirty() 
    {
        _foodobj.transform.Rotate(0,0,_speed, Space.Self);
    }
}



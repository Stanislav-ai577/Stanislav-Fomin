using UnityEngine;

public class Food : MonoBehaviour
{
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

    private void TakeEat(int _yam, string _iEat, string _foodLeft) 
    {
        _food = _food -_yam;
        _eatFood = _yam;
        Debug.Log($"" + _iEat + _eatFood + "%" + _foodLeft + _food + "%");
    }


    private void AddGettingClothesDirty(int _yami)
    {
        _dirt = _dirt + _yami;
        _clean = _clean - _yami;  
        Debug.Log($"I got dirty " +  _dirt + "% " + "clothes are clean on " + _clean + "%");
        
    }

    public void addClothesDirty() 
    {
        transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime);
    }


}



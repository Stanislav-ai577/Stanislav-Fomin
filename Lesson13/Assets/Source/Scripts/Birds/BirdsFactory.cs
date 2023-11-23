using UnityEngine;

public class BirdsFactory : MonoBehaviour
{
    [SerializeField] private Birds _birds;

    public Birds  CreateBird(Vector2 position)
    {
        Birds birdsCreated = Instantiate(_birds, position, Quaternion.identity);
        return birdsCreated;
    }
}

using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public Player CreatePlayer(Vector3 position)
    {
        return Instantiate(Resources.Load<Player>("Player"), position, Quaternion.identity).GetComponent<Player>();
    }
}

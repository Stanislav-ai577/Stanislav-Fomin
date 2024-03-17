using UnityEngine;

public abstract class Weapon : MonoBehaviour,IWeapon
{
    public abstract void Shoot();
    public abstract void TakeWeapon();
    public abstract void RemoveWeapon();
}

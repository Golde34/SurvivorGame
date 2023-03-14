using UnityEngine;

public interface IWeaponFactory 
{
    IWeapon CreateWeapon(Transform heroTransform);
}
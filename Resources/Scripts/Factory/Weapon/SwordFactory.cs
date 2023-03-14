using System.Threading;
using UnityEngine;

public class SwordFactory : IWeaponFactory
{
    public IWeapon CreateWeapon()
    {
        GameObject swordObj = new GameObject("Sword");
        Sword sword = swordObj.AddComponent<Sword>();
        sword.Damage = 5;
        sword.FitPoint = 0;
        return sword;
    }
}
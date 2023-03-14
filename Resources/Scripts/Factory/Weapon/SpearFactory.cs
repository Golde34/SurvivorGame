using System.Threading;
using UnityEngine;

public class SpearFactory : IWeaponFactory
{
    public IWeapon CreateWeapon()
    {
        GameObject spearObj = new GameObject("Spear");
        Spear spear = spearObj.AddComponent<Spear>();
        spear.Damage = 5;
        spear.FitPoint = 0;
        return spear;
    }
}
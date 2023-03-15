using System.Threading;
using UnityEngine;

public class KingFactory : IHeroFactory
{
    public IHero CreateHero()
    {
        GameObject kingObj = new GameObject("King");
        King king = kingObj.AddComponent<King>();
        king.Health = 180;
        king.currentHealth = king.Health;
        king.Damage = 20;
        king.Defense = 15;
        king.Speed = 1;
        king.DSpeed = 1;
        king.Range = 0.5f;
        king.UseWeapon();
        return king;
    }
}

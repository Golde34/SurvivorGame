using System.Threading;
using UnityEngine;

public class KnightFactory : IHeroFactory
{
    public IHero CreateHero()
    {
        GameObject knightObj = new GameObject("Knight");
        Knight knight = knightObj.AddComponent<Knight>();
        knight.Health = 180;
        knight.currentHealth = knight.Health;
        knight.Damage = 20;
        knight.Defense = 15;
        knight.Speed = 1;
        knight.DSpeed = 1;
        knight.Range = 0.2f;
        return knight;
    }
}

using System.Threading;
using UnityEngine;

public class KingFactory : MonoBehaviour, IHeroFactory
{
    public IHero CreateHero()
    {
        var kingGameObj = Resources.Load("Prefabs/HeroKing") as GameObject;
        var kingObj = Instantiate(kingGameObj);
        King king = kingObj.GetComponent<King>();
        king.Health = 180;
        king.currentHealth = king.Health;
        king.Damage = 20;
        king.Defense = 15;
        king.Speed = 1;
        king.DSpeed = 2;
        king.Range = 0.5f;

        return king;
    }
}

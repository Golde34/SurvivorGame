using System.Threading;
using UnityEngine;

public class KnightFactory : MonoBehaviour, IHeroFactory
{
    public IHero CreateHero()
    {
        var knightGameObj = Resources.Load("Prefabs/HeroKnight") as GameObject;
        var knightObj = Instantiate(knightGameObj);
        Knight knight = knightObj.GetComponent<Knight>();
        knight.Health = 150;
        knight.currentHealth = knight.Health;
        knight.Damage = 25;
        knight.Defense = 10;
        knight.Speed = 1.8f;
        knight.DSpeed = 1.5f;
        knight.Range = 0.6f;
        return knight;
    }
}

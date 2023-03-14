using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public IHeroFactory heroFactory;
    public void SetFactory(IHeroFactory factory) { heroFactory = factory; }
    public IHero SpawnHero()
    {
        IHero hero = heroFactory.CreateHero();
        return hero;
    }
}
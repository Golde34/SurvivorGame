using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public IHeroFactory heroFactory;
    public void SetFactory(IHeroFactory factory) { heroFactory = factory; }
    public void SpawnHero()
    {
        IHero hero = heroFactory.CreateHero();
        // Do additional setup here, like adding components or setting properties
        Debug.Log("Spawned hero with health " + hero.Health + " and damage " + hero.Damage);
    }
}
using UnityEngine;

public class CharacterStateEvent
{
    public IHero HeroState(HeroSpawner spawner, string heroString)
    {
        IHero hero;
        switch (heroString)
        {
            case "King":
                spawner.SetFactory(new KingFactory());
                hero = spawner.SpawnHero();
                return hero;
            case "Knight":
                spawner.SetFactory(new KnightFactory());
                hero = spawner.SpawnHero();
                return hero;
            default:
                spawner.SetFactory(new KingFactory());
                hero = spawner.SpawnHero();
                return hero;
        }
    }

    public IWeapon WeaponState(string weaponString, IWeapon _weapon)
    {
        IWeaponFactory factory;
        GameObject target;
        IWeapon weapon;
        switch (weaponString)
        {
            case "Sword":
                _weapon = new Sword();
                factory = new SwordFactory();
                target = GameObject.FindGameObjectWithTag("Hero");
                weapon = factory.CreateWeapon(target.gameObject.transform);
                return weapon;
            case "Spear":
                _weapon = new Spear();
                factory = new SpearFactory();
                target = GameObject.FindGameObjectWithTag("Hero");
                weapon = factory.CreateWeapon(target.gameObject.transform);
                return weapon;
            default:
                _weapon = new Sword();
                factory = new SwordFactory();
                target = GameObject.FindGameObjectWithTag("Hero");
                weapon = factory.CreateWeapon(target.gameObject.transform);
                return weapon;
        }
    }
}
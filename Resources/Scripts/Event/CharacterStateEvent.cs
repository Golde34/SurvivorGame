using UnityEngine;

public class CharacterStateEvent
{
    public IHero HeroState(HeroSpawner spawner, string heroString)
    {
        IHero hero;
        switch (heroString)
        {
            case "King":
                Debug.Log("King");
                spawner.SetFactory(new KingFactory());
                hero = spawner.SpawnHero();
                return hero;
            case "Knight":
                Debug.Log("Knight");
                spawner.SetFactory(new KnightFactory());
                hero = spawner.SpawnHero();
                return hero;
            default:
                Debug.Log("Default");
                spawner.SetFactory(new KingFactory());
                hero = spawner.SpawnHero();
                return hero;
        }
    }

    public IWeapon WeaponState(string weaponString)
    {
        IWeaponFactory factory;
        GameObject target;
        IWeapon weapon;
        switch (weaponString)
        {
            case "Sword":
                Debug.Log("Sword");
                factory = new SwordFactory();
                target = GameObject.FindGameObjectWithTag("Hero");
                weapon = factory.CreateWeapon(target.gameObject.transform);
                return weapon;
            case "Spear":
                Debug.Log("Spear");
                factory = new SpearFactory();
                target = GameObject.FindGameObjectWithTag("Hero");
                weapon = factory.CreateWeapon(target.gameObject.transform);
                return weapon;
            default:
                factory = new SwordFactory();
                target = GameObject.FindGameObjectWithTag("Hero");
                weapon = factory.CreateWeapon(target.gameObject.transform);
                return weapon;
        }
    }

    public IWeapon ChooseWeapon(string weaponString, IWeapon _weapon)
    {
        switch (weaponString)
        {
            case "Sword":
                _weapon = new Sword();
                return _weapon;
            case "Spear":
                _weapon = new Spear();
                return _weapon;
            default:
                _weapon = new Sword();
                return _weapon;
        }
    }
}
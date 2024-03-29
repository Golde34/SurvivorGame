﻿using UnityEngine;

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
            case "Wizard":
                Debug.Log("Wizard");
                spawner.SetFactory(new WizardFactory());
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
            case "Wand":
                Debug.Log("Wand");
                factory = new WandFactory();
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponsDatabase : ScriptableObject
{
    public ChooseCharacter[] weapons;

    public int WeaponsCount
    {
        get
        {
            return weapons.Length;
        }
    }

    public ChooseCharacter GetWeapons(int index)
    {
        return weapons[index];
    }
}

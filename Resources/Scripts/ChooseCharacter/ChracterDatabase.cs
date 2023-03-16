using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChracterDatabase : ScriptableObject
{
    public ChooseCharacter[] characters;

    public int CharacterCount
    {
        get
        {
            return characters.Length;
        }
    }

    public ChooseCharacter GetCharacter(int index)
    {
        return characters[index];
    }
}

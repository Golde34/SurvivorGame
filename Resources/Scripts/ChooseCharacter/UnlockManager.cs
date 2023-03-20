using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hero;
    void Start()
    {
        PlayerPrefs.DeleteKey("UnlockCharacter");
        if (!PlayerPrefs.HasKey("UnlockCharacter"))
        {
            PlayerPrefs.SetString("UnlockCharacter", "0");
        }
        string[] unlockedCharacterArray = PlayerPrefs.GetString("UnlockCharacter").Split(',');
        var allCharacter = hero.transform;
        for(var i = 0; i < allCharacter.childCount; i++)
        {
            var currenUnlockCharacter = allCharacter.GetChild(i);
            var CharacterIndex = currenUnlockCharacter.GetComponent<UnlockCharactor>().skinIndex.ToString();
            if(Array.IndexOf(unlockedCharacterArray, CharacterIndex) >= 0)
            {
                currenUnlockCharacter.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
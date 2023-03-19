using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CharacterManager : MonoBehaviour
{
    public ChracterDatabase characterDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedoption = 0;
    private bool haveKnight = false;
    private bool haveWazzard = false;

    void Start()
    {
       
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedoption = 0;
        }
        else
        {
            Load();
        }
        if (!PlayerPrefs.HasKey("UnlockCharacter"))
        {
            PlayerPrefs.SetString("UnlockCharacter", "0");
        }
        else
        {
            string[] unlockedCharacterArray = PlayerPrefs.GetString("UnlockCharacter").Split(',');
            if (Array.IndexOf(unlockedCharacterArray, "1") >= 0)
            {
                haveKnight = true;
                Debug.Log(haveKnight.ToString());

            }
            if(Array.IndexOf(unlockedCharacterArray, "2") >= 0)
            {
                haveWazzard = true;
            }
        }
        UpdateCharacter(selectedoption);
    }
    public void NextOption()
    {
        if (haveKnight == true && haveWazzard == false)
        {
            selectedoption++;
            if (selectedoption > 1)
            {
                selectedoption = 0;
            }

            UpdateCharacter(selectedoption);
        }
        else if (haveKnight == false && haveWazzard == true)
        {
            if (selectedoption == 0)
            {
                selectedoption = 2;
            }
            else
            {
                selectedoption = 0;
            }

            UpdateCharacter(selectedoption);
        }
        else if(haveKnight == false && haveWazzard == false)
        {
            selectedoption = 0;
            UpdateCharacter(selectedoption);
        }
        else
        {
            selectedoption++;
            if (selectedoption >= characterDB.CharacterCount)
            {
                selectedoption = 0;
            }

            UpdateCharacter(selectedoption);
        }
        Save();
    }
    public void Backoption()
    {
        if (haveKnight == true && haveWazzard == false)
        {
            selectedoption--;
            if (selectedoption < 0)
            {
                selectedoption = 1;
            }

            UpdateCharacter(selectedoption);
        }
        else if (haveKnight == false && haveWazzard == true)
        {
            if (selectedoption == 0)
            {
                selectedoption = 2;
            }
            else
            {
                selectedoption = 0;
            }

            UpdateCharacter(selectedoption);
        }
        else if (haveKnight == false && haveWazzard == false)
        {
            selectedoption = 0;
            UpdateCharacter(selectedoption);
        }
        else {
            selectedoption--;
            if (selectedoption < 0)
            {
                selectedoption = characterDB.CharacterCount - 1;
            }

            UpdateCharacter(selectedoption);
            }
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {

        ChooseCharacter character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
        Save();
    }


    private void Load()
    {
        selectedoption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedoption);
    }
}

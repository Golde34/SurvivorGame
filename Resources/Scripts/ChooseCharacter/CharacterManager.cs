using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public ChracterDatabase characterDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedoption = 0;

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
        UpdateCharacter(selectedoption);
    }
    public void NextOption()
    {
        selectedoption++;
        if(selectedoption >= characterDB.CharacterCount)
        {
            selectedoption = 0;
        }

        UpdateCharacter(selectedoption);
    }
    public void Backoption()
    {
        selectedoption--;
        if (selectedoption < 0)
        {
            selectedoption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedoption);
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

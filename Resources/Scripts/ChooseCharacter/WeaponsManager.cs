using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsManager : MonoBehaviour
{
    public WeaponsDatabase WeaponsDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedoption = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedWeaponsOption"))
        {
            selectedoption = 0;
        }
        else
        {
            Load();
        }
        UpdateWeapons(selectedoption);
    }
    public void NextOption()
    {
        selectedoption++;
        if (selectedoption >= WeaponsDB.WeaponsCount)
        {
            selectedoption = 0;
        }

        UpdateWeapons(selectedoption);
    }
    public void Backoption()
    {
        selectedoption--;
        if (selectedoption < 0)
        {
            selectedoption = WeaponsDB.WeaponsCount - 1;
        }

        UpdateWeapons(selectedoption);
        Save();
    }

    private void UpdateWeapons(int selectedOption)
    {
        ChooseCharacter character = WeaponsDB.GetWeapons(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
        Save();
    }


    private void Load()
    {
        selectedoption = PlayerPrefs.GetInt("selectedWeaponsOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedWeaponsOption", selectedoption);
    }
}

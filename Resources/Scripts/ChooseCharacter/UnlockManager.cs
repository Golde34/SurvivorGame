using Assets.Scripts.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hero;
    private TextMeshProUGUI gold;
    private int GoldCollect;
    private string totalGold;

    void Awake()
    {
        gold = GameObject.FindGameObjectWithTag("GoldText").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        TakeSaveTreasure();

        if (!PlayerPrefs.HasKey("GoldTextResult"))
        {
            GoldCollect = 0;
        }
        else
        {
            GoldCollect = Int32.Parse(PlayerPrefs.GetString("GoldTextResult", GoldCollect.ToString()));
        }
        PlayerPrefs.SetString("ToTalGold", (GoldCollect + Int32.Parse(PlayerPrefs.GetString("ToTalGold", totalGold))).ToString());

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
        
        //TakeSaveTreasure();
        gold.text = PlayerPrefs.GetString("ToTalGold", gold.text);
       
    }
    private void TakeSaveTreasure()
    {
        SaveJson saveJson = new SaveJson();
        // Load total treasure
        var jsonTextFile = Resources.Load<TextAsset>("Text/playerTreasure");

        // Calculate total treasure
        Treasure treasure = JsonUtility.FromJson<Treasure>(jsonTextFile.text);
        gold.text = treasure.totalTreasure.ToString();
    }
}

using Assets.Scripts.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCharactor : MonoBehaviour
{
    public int skinIndex;
    private TextMeshProUGUI gold;
    void Awake()
    {
        gold = GameObject.FindGameObjectWithTag("GoldText").GetComponent<TextMeshProUGUI>();
    }
    public void unlockCharactor()
    {
        var goldCount = Convert.ToInt32(gold.text);
        var unLock = transform.GetChild(1).gameObject;

        if (skinIndex == 1)
        {
            if (!(unLock.active == false) && goldCount >= 200)
            {
                unLock.SetActive(false);
                goldCount = goldCount - 200;
                gold.text = goldCount.ToString();
                SaveTreasure(goldCount);
                var unLockedCharacterArray = PlayerPrefs.GetString("UnlockCharacter").Split(',');
                if (Array.IndexOf(unLockedCharacterArray, skinIndex) < 0)
                {
                    Array.Resize(ref unLockedCharacterArray, unLockedCharacterArray.Length + 1);
                    unLockedCharacterArray[unLockedCharacterArray.Length - 1] = skinIndex.ToString();
                    PlayerPrefs.SetString("UnlockCharacter", string.Join(",", unLockedCharacterArray));
                    Debug.Log(PlayerPrefs.GetString("UnlockCharacter"));
                    //PlayerPrefs.DeleteKey("UnlockCharacter");
                }
            }
        }
        if(skinIndex == 2)
        {
            if (!(unLock.active == false) && goldCount >= 500)
            {
                unLock.SetActive(false);
                goldCount = goldCount - 500;
                gold.text = goldCount.ToString();
                SaveTreasure(goldCount);
                var unLockedCharacterArray = PlayerPrefs.GetString("UnlockCharacter").Split(',');
                if (Array.IndexOf(unLockedCharacterArray, skinIndex) < 0)
                {
                    Array.Resize(ref unLockedCharacterArray, unLockedCharacterArray.Length + 1);
                    unLockedCharacterArray[unLockedCharacterArray.Length - 1] = skinIndex.ToString();
                    PlayerPrefs.SetString("UnlockCharacter", string.Join(",", unLockedCharacterArray));
                    Debug.Log(PlayerPrefs.GetString("UnlockCharacter"));
                    //PlayerPrefs.DeleteKey("UnlockCharacter");
                }
            }
        }
    }
   
    public void SaveTreasure(int scoreCount)
    {
        SaveJson saveJson = new SaveJson();
        // Load total treasure
        var jsonTextFile = Resources.Load<TextAsset>("Text/playerTreasure");
        Treasure treasure = JsonUtility.FromJson<Treasure>(jsonTextFile.text);
        treasure.TotalTreasure = scoreCount;
        // Save treasure
        var savedJson = JsonUtility.ToJson(treasure);
        saveJson.WriteToFile("Resources/Text/playerTreasure.json", savedJson);

    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }
    private string GetFilePath(string fileName)
    {
        return Application.dataPath + "/" + fileName;
    }


}

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
        int goldCount = Int32.Parse(PlayerPrefs.GetString("ToTalGold", "500"));

        var unLock = transform.GetChild(1).gameObject;

        if (skinIndex == 1)
        {
            if (!(unLock.active == false) && goldCount >= 200)
            {
                unLock.SetActive(false);
                goldCount = goldCount - 200;
                gold.text = goldCount.ToString();
                PlayerPrefs.SetString("ToTalGold", goldCount.ToString());
                var unLockedCharacterArray = PlayerPrefs.GetString("UnlockCharacter").Split(',');
                if (Array.IndexOf(unLockedCharacterArray, skinIndex) < 0)
                {
                    Array.Resize(ref unLockedCharacterArray, unLockedCharacterArray.Length + 1);
                    unLockedCharacterArray[unLockedCharacterArray.Length - 1] = skinIndex.ToString();
                    PlayerPrefs.SetString("UnlockCharacter", string.Join(",", unLockedCharacterArray));
                    Debug.Log(PlayerPrefs.GetString("UnlockCharacter"));
                   
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
                PlayerPrefs.SetString("ToTalGold", goldCount.ToString());
                var unLockedCharacterArray = PlayerPrefs.GetString("UnlockCharacter").Split(',');
                if (Array.IndexOf(unLockedCharacterArray, skinIndex) < 0)
                {
                    Array.Resize(ref unLockedCharacterArray, unLockedCharacterArray.Length + 1);
                    unLockedCharacterArray[unLockedCharacterArray.Length - 1] = skinIndex.ToString();
                    PlayerPrefs.SetString("UnlockCharacter", string.Join(",", unLockedCharacterArray));
                    Debug.Log(PlayerPrefs.GetString("UnlockCharacter"));
                }
            }
        }
    }
}

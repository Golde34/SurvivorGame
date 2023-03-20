using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCharactor : MonoBehaviour
{
    public int skinIndex;
    private Image skinImage;
    private TextMeshProUGUI gold;

    void Awake()
    {
        gold = GameObject.FindGameObjectWithTag("GoldText").GetComponent<TextMeshProUGUI>();
    }

    public void unlockCharactor()
    {
        var goldCount = Convert.ToInt32(gold.text);
        var unLock = transform.GetChild(1).gameObject; 

        if (!(unLock.active == false))
        if (goldCount >= 100)
        {
            unLock.SetActive(false);
            goldCount = goldCount - 100;
            gold.text = goldCount.ToString();
            skinChange();
                var unLockedCharacterArray = PlayerPrefs.GetString("UnlockCharacter").Split(',');
                if (Array.IndexOf(unLockedCharacterArray, skinIndex) < 0)
                {
                    Array.Resize(ref unLockedCharacterArray, unLockedCharacterArray.Length + 1);
                    unLockedCharacterArray[unLockedCharacterArray.Length-1] = skinIndex.ToString();
                    PlayerPrefs.SetString("UnlockCharacter", string.Join(",", unLockedCharacterArray));
                    Debug.Log(PlayerPrefs.GetString("UnlockCharacter"));
                    //PlayerPrefs.DeleteKey("UnlockCharacter");
                }
        }
    }
    
    public void skinChange()
    {
        skinImage = transform.GetChild(0).GetComponent<Image>();
    }

   
}

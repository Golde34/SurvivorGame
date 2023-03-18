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
        if(!(unLock.active == false))
        if (goldCount >= 100)
        {
            unLock.SetActive(false);
            goldCount = goldCount - 100;
            gold.text = goldCount.ToString();
            skinChange();
        }
    }

    public void skinChange()
    {
        skinImage = transform.GetChild(0).GetComponent<Image>();
    }

   
}

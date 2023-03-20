using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] Button _backGameMenu;
    // Start is called before the first frame update
    TextMeshProUGUI currentDiamond;
    private void Awake()
    {
        currentDiamond = GameObject.FindGameObjectWithTag("GoldTextResult").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("GoldTextResult"))
        {
            currentDiamond.text = "0";
        }
        else
        {
            currentDiamond.text= PlayerPrefs.GetString("GoldTextResult", currentDiamond.text);
        }
        _backGameMenu.onClick.AddListener(LoadGameMenu);

    }

    private void LoadGameMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
    }
}

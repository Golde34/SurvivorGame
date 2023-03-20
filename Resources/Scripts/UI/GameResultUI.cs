using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameResultUI : MonoBehaviour
{
    [SerializeField] Button _backGameMenu;
    // Start is called before the first frame update
    void Start()
    {
        _backGameMenu.onClick.AddListener(LoadGameMenu);
    }

    private void LoadGameMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
    }
}

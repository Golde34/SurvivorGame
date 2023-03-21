using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUnlockCharacter : MonoBehaviour
{
    [SerializeField] Button _back;
    // Start is called before the first frame update
    void Start()
    {
        _back.onClick.AddListener(LoadGameMenu);
    }

    // Update is called once per frame
    private void LoadGameMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChooseCharactor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button _gameMenu;

    // Start is called before the first frame update
    void Start()
    {
        _gameMenu.onClick.AddListener(LoadNewGame);
    }

    private void LoadNewGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }
}

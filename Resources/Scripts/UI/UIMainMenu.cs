using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button _chooseCharactor;
    [SerializeField] Button _unlockCharacter;
    [SerializeField] Button _NewGame;
    // Start is called before the first frame update
    void Start()
    {
        _chooseCharactor.onClick.AddListener(LoadChosseCharactor);
        _unlockCharacter.onClick.AddListener(LoadUnlockCharacter);
        _NewGame.onClick.AddListener(LoadUnNewGame);
    }

    private void LoadChosseCharactor()
    {
        ScenesManager.Instance.LoadChooseCharacter();
    }
    private void LoadUnlockCharacter()
    {
        ScenesManager.Instance.LoadUnlockCharacter();
    }
    private void LoadUnNewGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button _chooseCharactor;

    // Start is called before the first frame update
    void Start()
    {
        _chooseCharactor.onClick.AddListener(LoadChosseCharactor);
    }

    private void LoadChosseCharactor()
    {
        ScenesManager.Instance.LoadChooseCharacter();
    }
}

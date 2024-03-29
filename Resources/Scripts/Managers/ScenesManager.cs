using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
  
    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu, 
        ChooseCharacter,
        UnlockCharacter,
        Level1,
        ResultGame,
    }

    public void LoadScene( Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    public void LoadUnlockCharacter()
    {
        SceneManager.LoadScene(Scene.UnlockCharacter.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Level1.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadChooseCharacter()
    {
        SceneManager.LoadScene(Scene.ChooseCharacter.ToString());
    }
    public void LoadResultGame()
    {
        SceneManager.LoadScene(Scene.ResultGame.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}

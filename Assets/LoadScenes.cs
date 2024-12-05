using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    [SerializeField] private string levelMapScene = "LevelSelection";
    [SerializeField] private string loadGameScene = "LoadScene";
    [SerializeField] private string settingsScene = "Settings_Scene";

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(levelMapScene);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(loadGameScene);
    }

    public void Settings()
    {
        SceneManager.LoadScene(settingsScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

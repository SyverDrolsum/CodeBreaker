using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string levelMapScene = "Level_Map";
    [SerializeField] private string loadGameScene = "Load_Scene";
    [SerializeField] private string settingsScene = "Settings_Scene";

    public void NewGame()
    {
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

using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    [SerializeField] private string levelScene;

    public void LevelScene()
    {
        SceneManager.LoadScene(levelScene);
    }
}

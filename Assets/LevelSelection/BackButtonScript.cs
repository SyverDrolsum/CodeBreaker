using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    [SerializeField] private string levelSelectionSceneName;

    public void GoBackToLevelSelection()
    {
        SceneManager.LoadScene(levelSelectionSceneName);
    }
}

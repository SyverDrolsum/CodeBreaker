using UnityEngine;
using UnityEngine.SceneManagement;      //handling scene transitions

public class LoadScene : MonoBehaviour
{

    [SerializeField] private string sceneName;      //name of the scene to load


    //function to load specific scene 
    public void LevelScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;      //handling scene transitions

public class FinishScene : MonoBehaviour
{

public string sceneToLoad;      //scene to load


    //function to detect if player is in contact 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);        //load new scene
        }
    }
}

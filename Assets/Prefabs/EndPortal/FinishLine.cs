using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScene : MonoBehaviour
{

public string sceneToLoad;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;        //reference to pause menu GameObject

    void Start()
    {
        Cursor.visible = false;     //hides cursor when the game starts
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))     //activate or deactivate pause menu
        {
            if (!pauseMenu.activeSelf)      //activate if not activated
            {
                Time.timeScale = 0f;        //freeze game   
                pauseMenu.SetActive(true);      //show pause menu
                Cursor.visible = true;      //make cursor visible
            }

            else
            {
                Time.timeScale = 1f;        //resume game
                pauseMenu.SetActive(false);     //hide pause menu
                Cursor.visible = false;     //hide cursor
            }
        }
    }

    //function to quit application
    public void quit()
    {
        Application.Quit();     //close game
    }

    //function to resume game
    public void resume()
    {
        Time.timeScale = 1f;        //resume game
        pauseMenu.SetActive(false);     //hide pause menu   
        Cursor.visible = false;     //hide cursor
    }
}
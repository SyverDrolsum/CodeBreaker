using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void SaveLevelProgress(int level)
    {
        PlayerPrefs.SetInt("Level" + level, 1);     //1 = level complete
        PlayerPrefs.Save();
        Debug.Log("Progress saved!");
    }

    public bool IsLevelCompleted(int level)
    {
        return PlayerPrefs.GetInt("Level" + level, 0) == 1;     //0 = level not completed
    }
}

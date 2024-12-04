using UnityEngine;

public class ProfessorManager : MonoBehaviour
{
    public GameObject HelpMove;
    public GameObject HelpJump;
    public GameObject HelpUseObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowPopup(HelpMove);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowPopup(GameObject popup)
    {
        popup.SetActive(true);
    }

    void HidePopup(GameObject popup)
    {
        popup.SetActive(false);
    }
}

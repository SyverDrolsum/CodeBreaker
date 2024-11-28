using UnityEngine;
using UnityEngine.UI;

public class LevelStatus : MonoBehaviour
{
    public enum LevelState { Locked, Current, Finished }
    public LevelState currentState;

    public Sprite redLight, organgeLight, greenLight;       //sprites for Locked,Current and Finished
    public Image lightIndicator;        //UI image for the light indicator

    public Button levelButton;      //reference to the button component 

    void Start()
    {
        UpdateState();
    }

   public void UpdateState()
    {
        switch (currentState)
        {
            case LevelState.Locked:
                lightIndicator.sprite = redLight;       //set light to red
                levelButton.interactable = false;       //disable button
                break;

            case LevelState.Current:
                lightIndicator.sprite = organgeLight;       //set light to orange
                levelButton.interactable = true;       //enable button
                break;

            case LevelState.Finished:
                lightIndicator.sprite = greenLight;       //set light to green
                levelButton.interactable = true;       //enable button
                break;
        }

    }

}

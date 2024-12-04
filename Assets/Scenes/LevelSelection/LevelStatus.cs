using UnityEngine;
using UnityEngine.UI;

public class LevelStatus : MonoBehaviour
{
    public enum LevelState { Locked, Current, Finished }
    public LevelState currentState;

    public Color lockedColor = new Color(1, 1, 1, 0.5f); // Faded for locked
    public Color currentColor = new Color(1, 1, 1, 1f); // Fully visible for current
    public Color finishedColor = new Color(1, 1, 1, 0.75f); // Semi-transparent for finished

    public Image lightIndicator;        //UI image for the light indicator
    public Image levelIcon;
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
                ApplyState(lockedColor, false);
                break;

            case LevelState.Current:
                ApplyState(currentColor, true);
                break;

            case LevelState.Finished:
                ApplyState(finishedColor, true);
                break;
        }

    }

    private void ApplyState(Color color, bool interactable)
    {
        if (lightIndicator != null)
        {
            lightIndicator.color = color; // Set the color/opacity of the level icon
            levelIcon.color = color;
        }

        if (levelButton != null)
        {
            levelButton.interactable = interactable; // Enable or disable interaction
        }
    }

}

using UnityEngine;

public class SizeManager : MonoBehaviour
{
    public GameObject normalBlip;
    public GameObject mediumBlip;
    public GameObject smallBlip;


    private GameObject currentState;

    public GameObject Player => currentState;


    // Start is called once before the first execution of Update after the MonoBehaviour is created7
    //Starting with normal sized blip
    void Start()
    {
        SwitchToState(normalBlip);
    }

    //Change to medium state
    public void ToMediumState() {
        SwitchToState(mediumBlip);
    }

    //Change to small state
    public void ToSmallState()
    {
        SwitchToState(smallBlip);
    }

    //Change to normal state
    public void ToNormalState()
    {
        SwitchToState(normalBlip);
    }

    private void SwitchToState(GameObject newState)
    {
        Vector3 spawnPosition = transform.position;
        // Destroy the current state GameObject
        if (currentState != null)
        {
            //Have the current position be the new spawn position of the new state
            spawnPosition = currentState.transform.position;
            Destroy(currentState);
        }
        // Instantiate the new state
        currentState = Instantiate(newState, spawnPosition, transform.rotation, transform);
    }
}

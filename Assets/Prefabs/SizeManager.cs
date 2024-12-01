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

    //When switching state changes the position based on the virus position to give
    //the illution that the player got pushed.
    private void SwitchToState(GameObject newState)
    {
    Vector3 spawnPosition = transform.position;

    if (currentState != null)
    {
        Vector3 virusPosition = GameObject.FindGameObjectWithTag("Virus").transform.position;
        Vector3 direction = (spawnPosition - virusPosition).normalized;

        Vector3 pushOffset = direction * 1.0f;
        spawnPosition = currentState.transform.position + pushOffset;

        Destroy(currentState);
    }
    
    currentState = Instantiate(newState, spawnPosition, transform.rotation, transform);
    }

}

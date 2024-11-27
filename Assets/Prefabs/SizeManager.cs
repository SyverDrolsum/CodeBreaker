using UnityEngine;

public class SizeManager : MonoBehaviour
{
    public GameObject normalBlip;
    public GameObject mediumBlip;
    public GameObject smallBlip;


    private GameObject currentState;

    public GameObject Player => currentState;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwitchToState(normalBlip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMediumState() {
        SwitchToState(mediumBlip);
    }

    public void ToSmallState()
    {
        // Switch to the powered-up state
        SwitchToState(smallBlip);
    }

    public void ToNormalState()
    {
        // Return to the normal state
        SwitchToState(normalBlip);
    }

    private void SwitchToState(GameObject newStatePrefab)
    {
        Vector3 spawnPosition = transform.position;
        // Destroy the current state GameObject
        if (currentState != null)
        {
            spawnPosition = currentState.transform.position;
            Destroy(currentState);
        }

        // Instantiate the new state prefab
        currentState = Instantiate(newStatePrefab, spawnPosition, transform.rotation, transform);
    }
}

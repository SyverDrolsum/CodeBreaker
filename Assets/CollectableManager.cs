using TMPro;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager instance { get; private set; }
    public TextMeshProUGUI collectableCountText;

    private void Awake()
    {
        //Makes sure there is only one instance 
        if (instance != null && instance != this)
            Destroy(gameObject);      // Destroys duplicates
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);      // Make this object stay across scenes

        // Subscribe to the OnCollected event
        CollectableBehaviour.OnCollected += OnCollectableCollected;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnCollected event
        CollectableBehaviour.OnCollected -= OnCollectableCollected;
    }

    void OnCollectableCollected(CollectableBehaviour collectableBehaviour)
    {
        collectableCountText.text = CollectableBehaviour.collectableCount.ToString();
    }
}

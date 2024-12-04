using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject[] platformPrefabs;        //platform-prefabs to spawn
    public Transform[] spawnPoints;     //spawn points where platforms appear
    private bool isActive = false;
    private bool playerInRange = false;
    public DestroyWhenDone destroyWhenDone = null;
    [SerializeField] private AudioClip leverSound;


    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();        //get animator component attached to the lever GameObject
    }

    private void Update()
    {
        //check if player is in range and pressing E

        if (playerInRange && !isActive && Input.GetKeyDown(KeyCode.E))
        {
            ActivateLever();        //trigger lever
            anim.SetTrigger("isPulled");       //play lever animation
            SoundManager.instance.PlaySound(leverSound);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered lever range.");
            SoundManager.instance.PlaySound(leverSound);

        }
    }

    //check if player enters levers trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited lever range.");
        }
    }

    private void ActivateLever()
    {
        //destroyWhenDone.DestroyPopUp();
        isActive = true;
        Debug.Log("Lever activated! Platforms spawned.");

        //ensures number of platform prefabs matches number of spawn point
        if (platformPrefabs.Length != spawnPoints.Length)
        {
            Debug.LogError("Platform Prefabs and Spawn Points arrays do not match in length!");
            return;
        }

        //spawn platforms
        for (int i = 0; i < platformPrefabs.Length && i < spawnPoints.Length; i++)
        {
            Instantiate(platformPrefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
           
        }
    }
}

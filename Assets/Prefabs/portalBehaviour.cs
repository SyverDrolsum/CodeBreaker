using System.Collections;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    public Transform destination;
    public SizeManager sizeManager;

    [SerializeField] private AudioClip teleportSound;


    GameObject player;

    private bool canTeleport = false;


    public void Update()
    {
        //When player touches portal and W is pressed, teleport to other portal
        if(canTeleport && Input.GetKeyUp(KeyCode.W))
        {
            SoundManager.instance.PlaySound(teleportSound);
            player = sizeManager.Player;
            player.transform.position = destination.transform.position;
        }
    }
    //When touching Player, canTeleport is true
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTeleport = true;
        }
    }
    //When not touching Player anymore, canTeleport is false
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTeleport = false;
        }
    }
}

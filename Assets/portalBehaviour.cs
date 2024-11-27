using System.Collections;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    public Transform destination;
    public SizeManager sizeManager;

    GameObject player;

    private bool canTeleport = false;

    public void Update()
    {
        if(canTeleport && Input.GetKeyUp(KeyCode.W))
        {
            player = sizeManager.Player;
            player.transform.position = destination.transform.position;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTeleport = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canTeleport = false;
        }
    }
}

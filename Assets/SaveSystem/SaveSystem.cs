using UnityEngine;

public static class SaveSystem
{
    public static Vector3 checkpointPosition;
    public static int checkpointHealth;

    public static void SaveCheckpoint(Vector3 position, int health)
    {
        checkpointPosition = position;
        checkpointHealth = health;
    }

    public static (Vector3, int) LoadCheckpoint()
    {
        return (checkpointPosition, checkpointHealth);
    }
}

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 checkpointPosition; // Static so it can be accessed globally
    public static bool checkpointActivated = false; // To ensure it's activated only once

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has touched the bubble
        if (other.CompareTag("Player"))
        {
            checkpointPosition = transform.position;  // Store the bubble's position
            checkpointActivated = true;  // Mark the checkpoint as activated
        }
    }
}

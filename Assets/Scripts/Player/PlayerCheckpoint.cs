using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 checkpointPosition;

    void Start()
    {
        checkpointPosition = transform.position; // Save starting position
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint; // Update
    }

    public void ResetPlayer()
    {
        transform.position = checkpointPosition; // Move player
    }
}

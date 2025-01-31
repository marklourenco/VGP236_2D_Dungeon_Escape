using UnityEngine;

public class Arrows : MonoBehaviour
{
    [Header("Circle Settings")]
    public float lifetime = 5f; // Time before the circle disappears

    void Start()
    {
        // Destroy the circle after the set lifetime
        Destroy(gameObject, lifetime);
    }

    // Detect collision with player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Call the method to send the player back to the last checkpoint
            PlayerCheckpoint playerCheckpoint = collision.collider.GetComponent<PlayerCheckpoint>();
            if (playerCheckpoint != null)
            {
                playerCheckpoint.ResetPlayer();
            }

            // Destroy the circle after collision
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

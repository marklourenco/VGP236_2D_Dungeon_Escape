using UnityEditor.Tilemaps;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Header("Doors to Toggle")]
    public GameObject door1;
    public GameObject door2;
    public SpriteRenderer lever;

    [SerializeField] private bool isDoor1Open = true;
    [SerializeField] private bool isDoor2Open = false;

    private void Start()
    {
        if (door1 != null)
        {
            ToggleDoor(door1, isDoor1Open);
        }

        if (door2 != null)
        {
            ToggleDoor(door2, isDoor2Open);
        }
    }

    private void ToggleDoors()
    {
        if (door1 != null)
        {
            isDoor1Open = !isDoor1Open;
            ToggleDoor(door1, isDoor1Open);
        }

        if (door2 != null)
        {
            isDoor2Open = !isDoor2Open;
            ToggleDoor(door2, isDoor2Open);
        }
    }

    private void ToggleDoor(GameObject door, bool isOpen)
    {
        Collider2D doorCollider = door.GetComponent<Collider2D>();
        SpriteRenderer doorSprite = door.GetComponent<SpriteRenderer>();

        if (doorCollider != null)
            doorCollider.enabled = !isOpen; // Disable collider to "open" door

        if (doorSprite != null)
            doorSprite.enabled = !isOpen; // Disable sprite to "open" door

        lever.flipX = !isOpen;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleDoors();
        }
    }
}

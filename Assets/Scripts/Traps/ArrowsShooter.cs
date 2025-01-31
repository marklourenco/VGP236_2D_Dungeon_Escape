using UnityEngine;

public class ArrowsShooter : MonoBehaviour
{
    [Header("Trap Settings")]
    public GameObject arrowPrefab;
    public float shootInterval = 2f;
    public float shootForce = 10f;

    private float timeSinceLastShot = 0f;

    public bool right;
    public bool left;
    public bool up;
    public bool down;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootInterval)
        {
            Shootarrow();
            timeSinceLastShot = 0f;
        }
    }

    void Shootarrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (right)
        {
            if (rb != null)
            {
                rb.AddForce(Vector2.right * shootForce, ForceMode2D.Impulse);
            }
        }
        if (left)
        {
            if (rb != null)
            {
                rb.AddForce(Vector2.left * shootForce, ForceMode2D.Impulse);
            }
        }
        if (up)
        {
            if (rb != null)
            {
                rb.AddForce(Vector2.up * shootForce, ForceMode2D.Impulse);
            }
        }
        if (down)
        {
            if (rb != null)
            {
                rb.AddForce(Vector2.down * shootForce, ForceMode2D.Impulse);
            }
        }
    }
}

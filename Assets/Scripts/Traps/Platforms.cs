using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float waitTime = 1f;

    private Vector3 startPos, endPos;
    private bool isWaiting = false;
    private float lerpTime = 0f;

    void Start()
    {
        if (pointA != null && pointB != null)
        {
            startPos = pointA.position;
            endPos = pointB.position;
        }
    }

    void Update()
    {
        if (!isWaiting && pointA != null && pointB != null)
        {
            lerpTime += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(lerpTime, 1));

            if (lerpTime >= 1f)
            {
                StartCoroutine(PauseAtPoint());
            }
        }
    }

    IEnumerator PauseAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        SwapPoints();
        lerpTime = 0f;
        isWaiting = false;
    }

    void SwapPoints()
    {
        Vector3 temp = startPos;
        startPos = endPos;
        endPos = temp;
    }
}

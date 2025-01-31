using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Image blackScreen;
    public TextMeshProUGUI text;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            blackScreen.enabled = true;
            text.enabled = true;
        }
    }
}

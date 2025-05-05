using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{
    public GameObject eKeyPromptIcon;

    private void Start()
    {
        if (eKeyPromptIcon != null)
            eKeyPromptIcon.SetActive(false); // Baþlangýçta gizle
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && eKeyPromptIcon != null)
        {
            eKeyPromptIcon.SetActive(true); // Oyuncu yaklaþýnca göster
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && eKeyPromptIcon != null)
        {
            eKeyPromptIcon.SetActive(false); // Oyuncu uzaklaþýnca gizle
        }
    }
}

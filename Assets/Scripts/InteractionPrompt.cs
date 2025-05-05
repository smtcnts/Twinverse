using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{
    public GameObject eKeyPromptIcon;

    private void Start()
    {
        if (eKeyPromptIcon != null)
            eKeyPromptIcon.SetActive(false); // Ba�lang��ta gizle
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && eKeyPromptIcon != null)
        {
            eKeyPromptIcon.SetActive(true); // Oyuncu yakla��nca g�ster
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && eKeyPromptIcon != null)
        {
            eKeyPromptIcon.SetActive(false); // Oyuncu uzakla��nca gizle
        }
    }
}

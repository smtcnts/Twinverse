using UnityEngine;
using UnityEngine.UI; // UI ile etkileşim için

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel;
    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            dialoguePanel.SetActive(!dialoguePanel.activeSelf); // Aç/kapat
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            dialoguePanel.SetActive(false); // Çıkınca kapat
        }
    }
}
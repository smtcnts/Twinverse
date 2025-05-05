using UnityEngine;
using TMPro;

public class NPCInteractionZone : MonoBehaviour
{
    public GameObject dialoguePanel;            // UI Panel (World Space)
    public TextMeshProUGUI dialogueText;        // Yazý alaný
    public string message = "Merhaba yolcu!";   // Gösterilecek metin
    public float displayTime = 3f;              // Ne kadar açýk kalacak

    private bool playerNearby = false;
    private float timer = 0f;

    void Start()
    {
        dialoguePanel.SetActive(false);         // Baþta panel gizli
    }

    void Update()
    {
        // E tuþuna basýlýrsa ve oyuncu yakýndaysa
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
        }

        // Konuþma süresi bittiyse kapat
        if (dialoguePanel.activeSelf)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                dialoguePanel.SetActive(false);
            }
        }
    }

    void ShowDialogue()
    {
        //dialogueText.text = message;
        dialoguePanel.SetActive(true);
        timer = displayTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Oyuncu etkileþim alanýna girdi.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialoguePanel.SetActive(false);
            Debug.Log("Oyuncu alandan çýktý.");
        }
    }
}

using UnityEngine;
using TMPro;

public class NPCInteractionZone : MonoBehaviour
{
    public GameObject dialoguePanel;            // UI Panel (World Space)
    public TextMeshProUGUI dialogueText;        // Yaz� alan�
    public string message = "Merhaba yolcu!";   // G�sterilecek metin
    public float displayTime = 3f;              // Ne kadar a��k kalacak

    private bool playerNearby = false;
    private float timer = 0f;

    void Start()
    {
        dialoguePanel.SetActive(false);         // Ba�ta panel gizli
    }

    void Update()
    {
        // E tu�una bas�l�rsa ve oyuncu yak�ndaysa
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
        }

        // Konu�ma s�resi bittiyse kapat
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
            Debug.Log("Oyuncu etkile�im alan�na girdi.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            dialoguePanel.SetActive(false);
            Debug.Log("Oyuncu alandan ��kt�.");
        }
    }
}

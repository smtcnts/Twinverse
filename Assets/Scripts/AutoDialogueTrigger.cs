using UnityEngine;
using TMPro;

public class AutoDialogueTrigger : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public float displayTime = 3f;

    private float timer;

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Text'e müdahale etmeden paneli aç
            dialoguePanel.SetActive(true);
            timer = displayTime;
        }
    }

    void Update()
    {
        if (dialoguePanel.activeSelf)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                dialoguePanel.SetActive(false);
            }
        }
    }
}

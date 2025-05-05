using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public Animator chestAnimator;
    private bool isPlayerNearby = false;
    private bool isOpened = false;

    void Update()
    {
        if (isPlayerNearby && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            chestAnimator.SetTrigger("Open");
            isOpened = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}

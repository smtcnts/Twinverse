using UnityEngine;
using System.Collections;

public class PortalTeleport : MonoBehaviour
{
    public Transform destinationPortal;
    private bool isPlayerNearby = false;
    private Transform player;

    public ScreenFader screenFader; // 👈 Ekran karartma sistemi

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (player != null && destinationPortal != null)
            {
                StartCoroutine(TeleportWithFade());
            }
        }
    }

    IEnumerator TeleportWithFade()
    {
        // 👻 Ekranı karart
        yield return screenFader.FadeOut();

        // ⛔ Bu noktada ekran zifiri karanlık, şimdi ışınla
        player.position = destinationPortal.position;

        // ⏱ Kamera takip etsin ve otursun diye biraz daha bekle
        yield return new WaitForSeconds(0.5f); // Gerekirse artır: 0.5f deneyebilirsin

        // 🌤 Sonra ekranı aç
        yield return screenFader.FadeIn();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            player = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            player = null;
        }
    }
}

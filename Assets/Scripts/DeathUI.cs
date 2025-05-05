using UnityEngine;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    public GameObject panel;
    public Button respawnButton;

    public void Show()
    {
        panel.SetActive(true);
        respawnButton.gameObject.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
        respawnButton.gameObject.SetActive(false);
    }
}

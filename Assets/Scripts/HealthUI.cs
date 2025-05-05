using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject[] hearts;

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }
}

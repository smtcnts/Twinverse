using UnityEngine;
using System.Collections;

public class LavaDripSpawner : MonoBehaviour
{
    public GameObject lavaDripPrefab;
    public float spawnInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnDrip();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnDrip()
    {
        if (lavaDripPrefab != null)
        {
            Instantiate(lavaDripPrefab, transform.position, Quaternion.identity);
            Debug.Log("💧 Yeni damla oluşturuldu");
        }
        else
        {
            Debug.LogError("❌ lavaDripPrefab atanmadı!");
        }
    }

}

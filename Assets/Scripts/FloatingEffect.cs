using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatStrength = 0.5f; // Ne kadar yukarý-aþaðý oynasýn
    public float floatSpeed = 2f;      // Ne kadar hýzlý oynasýn

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Yukarý-aþaðý dalga hareketi
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = new Vector3(initialPosition.x, initialPosition.y + newY, initialPosition.z);
    }
}

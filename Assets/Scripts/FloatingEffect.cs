using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatStrength = 0.5f; // Ne kadar yukar�-a�a�� oynas�n
    public float floatSpeed = 2f;      // Ne kadar h�zl� oynas�n

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Yukar�-a�a�� dalga hareketi
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = new Vector3(initialPosition.x, initialPosition.y + newY, initialPosition.z);
    }
}

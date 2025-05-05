using UnityEngine;

public class SmokeSway : MonoBehaviour
{
    public float swayAmount = 0.5f;     // Ne kadar sa�a sola oynas�n
    public float swaySpeed = 1f;        // Ne kadar h�zl� sallans�n
    private Vector3 initialPosition;
    private float randomOffset;

    void Start()
    {
        initialPosition = transform.localPosition;
        randomOffset = Random.Range(0f, 100f); // Her duman farkl� zamanlamayla sallans�n
    }

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed + randomOffset) * swayAmount;
        transform.localPosition = new Vector3(initialPosition.x + sway, initialPosition.y, initialPosition.z);
    }
}

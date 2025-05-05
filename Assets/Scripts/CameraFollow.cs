using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;     // Takip edilecek karakter
    public Vector3 offset;       // Kameran�n pozisyon fark�
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}

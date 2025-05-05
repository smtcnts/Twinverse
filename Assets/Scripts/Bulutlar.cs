using UnityEngine;

public class Bulutlar : MonoBehaviour
{
    public GameObject bulut1;
    public GameObject bulut2;
    // Bulutlar�n h�zlar�
    public float bulut1Speed = 0.5f;
    public float bulut2Speed = 0.8f;
    // Bulutlar�n resetlenece�i X s�n�rlar�
    public float rightLimit = 10f;
    public float leftLimit = -10f;
    void Update()
    {
        MoveBulut1();
        MoveBulut2();
    }
    void MoveBulut1()
    {
        // Sa�a do�ru hareket
        bulut1.transform.Translate(Vector2.right * bulut1Speed * Time.deltaTime);
        // Sa� limit ge�ilince sola tekrar d�n
        if (bulut1.transform.position.x > rightLimit)
        {
            bulut1.transform.position = new Vector2(leftLimit, bulut1.transform.position.y);
        }
    }
    void MoveBulut2()
    {
        // Sola do�ru hareket
        bulut2.transform.Translate(Vector2.left * bulut2Speed * Time.deltaTime);
        // Sol limit ge�ilince sa�a tekrar d�n
        if (bulut2.transform.position.x < leftLimit)
        {
            bulut2.transform.position = new Vector2(rightLimit, bulut2.transform.position.y);
        }
    }
}
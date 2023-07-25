using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek player�n Transform bile�eni
    public float smoothSpeed = 0.125f; // Takip etme yumu�akl���
    public Vector3 offset; // Kameran�n player ile aras�ndaki mesafe

    void LateUpdate()
    {
        if (target == null)
            return;

        // Player�n pozisyonunu hedef alarak kameran�n hedef pozisyona ula�mas�n� sa�lay�n
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Kameran�n Z konumunu g�ncelleyin ve sabit tutun
        smoothedPosition.z = transform.position.z;

        // Kameray� d�zg�nce takip etmek i�in LateUpdate kullan�n
        transform.position = smoothedPosition;
    }
}

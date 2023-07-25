using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek playerýn Transform bileþeni
    public float smoothSpeed = 0.125f; // Takip etme yumuþaklýðý
    public Vector3 offset; // Kameranýn player ile arasýndaki mesafe

    void LateUpdate()
    {
        if (target == null)
            return;

        // Playerýn pozisyonunu hedef alarak kameranýn hedef pozisyona ulaþmasýný saðlayýn
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Kameranýn Z konumunu güncelleyin ve sabit tutun
        smoothedPosition.z = transform.position.z;

        // Kamerayý düzgünce takip etmek için LateUpdate kullanýn
        transform.position = smoothedPosition;
    }
}

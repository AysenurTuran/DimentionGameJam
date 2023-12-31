using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 2f;

    public float minSize = 2f;
    public float maxSize = 10f;

    void Update()
    {
        // Mouse ScrollWheel'den yakınlaştırma ve uzaklaştırmayı al
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Yakınlaştırmayı ve uzaklaştırmayı kamera boyutuna ekleyin
        Camera.main.orthographicSize -= zoomInput * zoomSpeed;

        // Kamera boyutunu minSize ve maxSize sınırlarında kısıtlayın
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minSize, maxSize);
    }
}
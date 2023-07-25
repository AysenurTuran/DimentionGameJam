using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 2f;

    public float minSize = 2f;
    public float maxSize = 10f;

    void Update()
    {
        // Mouse ScrollWheel'den yak�nla�t�rma ve uzakla�t�rmay� al
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Yak�nla�t�rmay� ve uzakla�t�rmay� kamera boyutuna ekleyin
        Camera.main.orthographicSize -= zoomInput * zoomSpeed;

        // Kamera boyutunu minSize ve maxSize s�n�rlar�nda k�s�tlay�n
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minSize, maxSize);
    }
}
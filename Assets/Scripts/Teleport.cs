using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; // Işınlanılacak hedef nokta
    public bool requiresKey = true; // Işınlanmak için anahtar gerekiyor mu?

    private void OnCollisionEnter2D(Collision2D point)
    {
        if (point.gameObject.CompareTag("Player"))
        {
            Movement playerMovement = point.gameObject.GetComponent<Movement>();
            if (playerMovement != null && (!requiresKey || playerMovement.HasKey()))
            {
                point.gameObject.transform.position = teleportTarget.position;
            }
        }
    }
}

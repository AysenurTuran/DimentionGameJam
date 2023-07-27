using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D door)
    {
        if (door.gameObject.CompareTag("Recordable"))
        {
            Movement playerMovement = door.gameObject.GetComponent<Movement>();
            if (playerMovement != null && playerMovement.HasKey()) // Anahtara sahip mi kontrolü
            {
                SceneManager.LoadScene(_scene.buildIndex + 1);
            }
        }
    }
}

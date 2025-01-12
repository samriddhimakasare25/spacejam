using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint; // The original spawn point for the player

    private Vector3 originalPosition;

    void Start()
    {
        // Store the original position of the player
        originalPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player touches the blade
        if (collision.gameObject.CompareTag("blade"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        // Reset the player's position to the original position or respawn point
        transform.position = respawnPoint != null ? respawnPoint.position : originalPosition;
    }
}


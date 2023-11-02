using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    [SerializeField] Transform[] teleportDestinations; // Array of teleportation destinations
    [SerializeField] GameObject player;

    // Define a KeyCode for triggering the teleport (you can change this to any key)
    public KeyCode teleportKey = KeyCode.T;

    private int currentDestinationIndex = 0;
    private bool isTeleporting = false;
    private Vector3 playerSpawnPoint; // Store the player's spawn point

    private void Start()
    {
        // Store the initial spawn point
        playerSpawnPoint = player.transform.position;
    }

    private void Update()
    {
        // Check if the teleport key is pressed and teleport is not in progress
        if (!isTeleporting && Input.GetKeyDown(teleportKey))
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        // Set isTeleporting to true to prevent further teleports
        isTeleporting = true;

        // Ensure the OnTriggerEnter method won't trigger during teleport
        GetComponent<Collider>().enabled = false;

        // Wait for a short duration before teleporting
        yield return new WaitForSeconds(1);

        // Ensure the current destination index is within bounds
        if (currentDestinationIndex >= 0 && currentDestinationIndex < teleportDestinations.Length)
        {
            // Teleport the player to the specified destination
            Vector3 destination = teleportDestinations[currentDestinationIndex].position;
            player.transform.position = destination;

            // Update the player's spawn point to the new location
            playerSpawnPoint = player.transform.position;
        }

        // Reset isTeleporting after teleporting
        isTeleporting = false;

        // Re-enable the collider to allow further teleportation
        GetComponent<Collider>().enabled = true;
    }

    // You can call this function to cycle to the next destination point
    public void CycleDestination()
    {
        currentDestinationIndex = (currentDestinationIndex + 1) % teleportDestinations.Length;
    }

    // You can call this function whenever you want to reset the player's position to the spawn point
    public void ResetPlayerPosition()
    {
        player.transform.position = playerSpawnPoint;
    }
}
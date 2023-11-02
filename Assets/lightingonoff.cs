using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightingonoff : MonoBehaviour
{
    public GameObject txtToDisplay; // Display the UI text
    private bool PlayerInZone; // Check if the player is in the trigger
    public GameObject lightorobj;

    private Animator _animator; // Reference to the Animator component

    private void Start()
    {
        PlayerInZone = false; // Player not in zone       
        txtToDisplay.SetActive(false);
        //
        // Get the Animator component reference
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetMouseButtonDown(0)) // If in zone and left mouse button is clicked
        {
            Debug.Log("test");

            lightorobj.SetActive(!lightorobj.activeSelf);
            gameObject.GetComponent<AudioSource>().Play();

            // Trigger the "SwitchTrigger" parameter
            _animator.SetTrigger("SwitchTrigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // If player enters zone
        {
            Debug.Log("test");
            txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // If player exits zone
        {
            txtToDisplay.SetActive(false);
            PlayerInZone = false;
        }
    }
}
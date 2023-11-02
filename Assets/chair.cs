using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair : MonoBehaviour
{
    public GameObject playerStanding, playerSitting, intText, standText;
    public bool interactable, sitting;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            // Only set interactable to true if it's not already sitting.
            if (!sitting)
            {
                intText.SetActive(true);
                interactable = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                intText.SetActive(false);
                standText.SetActive(true);
                playerSitting.SetActive(true);
                sitting = true;
                playerStanding.SetActive(false);
                interactable = false; // Set interactable to false after sitting down.
            }
        }
        if (sitting)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerSitting.SetActive(false);
                standText.SetActive(false);
                playerStanding.SetActive(true);
                sitting = false;
                interactable = true; // Set interactable to true after standing up.
            }
        }
    }
}
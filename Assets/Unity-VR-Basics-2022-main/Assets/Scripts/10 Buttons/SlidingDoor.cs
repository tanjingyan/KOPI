using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    private Animator doorAnimator; // Reference to the Animator component.

    private bool _openDoor = false;

    private void Start()
    {
        // Initialize the doorAnimator variable with the Animator component.
        doorAnimator = GetComponent<Animator>();
    }

    public void ToggleDoorOpen()
    {
        if (!_openDoor)
        {
            // If the door is closed, set the "Open" trigger parameter in the Animator.
            doorAnimator.SetBool("open",true);
        }
        else
        {
            // If the door is open, set the "Close" trigger parameter in the Animator.
            doorAnimator.SetBool("open",false);
        }

        _openDoor = !_openDoor;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform pickupPoint; // A reference to the pickup point (empty GameObject) where the object will be held.

    private bool isPickedUp = false; // A flag to indicate if the object is currently picked up.
    private Vector3 offset; // Store the offset from the pickup point.

    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor and make it invisible when the game starts.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object is picked up.
        if (isPickedUp)
        {
            // Update the position of the object to match the pickup point's position.
            transform.position = pickupPoint.position + offset;
        }
    }

    void OnMouseDown()
    {
        // Check if the object is not already picked up.
        if (!isPickedUp)
        {
            // Calculate the offset between the object's position and the pickup point's position.
            offset = transform.position - pickupPoint.position;

            // Make the object a child of the pickup point.
            transform.parent = pickupPoint;

            // Disable gravity for the object.
            GetComponent<Rigidbody>().useGravity = false;

            // Set the object's velocity to zero to stop any previous motion.
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            // Freeze the object's rotation to prevent it from rotating while picked up.
            GetComponent<Rigidbody>().freezeRotation = true;

            // Disable the object's box collider to prevent collision interactions while picked up.
            GetComponent<BoxCollider>().enabled = false;

            // Set the flag to indicate that the object is picked up.
            isPickedUp = true;
        }
    }

    void OnMouseUp()
    {
        // Check if the object is picked up.
        if (isPickedUp)
        {
            // Detach the object from the pickup point.
            transform.parent = null;

            // Enable gravity for the object to let it fall naturally.
            GetComponent<Rigidbody>().useGravity = true;

            // Allow the object's rotation to change again.
            GetComponent<Rigidbody>().freezeRotation = false;

            // Enable the object's box collider to allow collision interactions.
            GetComponent<BoxCollider>().enabled = true;

            // Set the flag to indicate that the object is no longer picked up.
            isPickedUp = false;
        }
    }
}
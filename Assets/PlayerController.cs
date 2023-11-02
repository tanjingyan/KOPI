using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this to control the movement speed.
    public float jumpForce = 10.0f; // The force applied when jumping.
    private Rigidbody rb; // Reference to the Rigidbody component.
    private bool isGrounded = true; // Flag to check if the player is grounded.

    void Start()
    {
        // Get the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the player's keyboard.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction.
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Calculate the movement vector and scale it by the moveSpeed.
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;

        // Move the player.
        transform.Translate(movement);

        // Check for player jump input.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply an upward force to simulate jumping.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Set the grounded flag to false to prevent multiple jumps in mid-air.
        }
    }

    // Use FixedUpdate for physics-related checks.
    void FixedUpdate()
    {
        // Check if the player is grounded.
        CheckGrounded();
    }

    void CheckGrounded()
    {
        // Create a ray that points downward from the player's center.
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Check if the ray hits something within a small distance.
        if (Physics.Raycast(ray, out hit, 0.1f))
        {
            isGrounded = true; // The player is grounded.
        }
        else
        {
            isGrounded = false; // The player is not grounded.
        }
    }
}

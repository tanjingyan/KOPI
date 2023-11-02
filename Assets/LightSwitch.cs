using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private Animator animator;
    private bool isButtonPressed = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check for player input or any other condition to toggle the button state.
        if (Input.GetMouseButtonDown(0)) // Example: Press "E" to toggle the button state.
        {
            ToggleButtonState();
        }
    }

    private void ToggleButtonState()
    {
        isButtonPressed = !isButtonPressed;
        animator.SetBool("button", isButtonPressed); // "Button" is the parameter name in the Animator Controller.
    }
}
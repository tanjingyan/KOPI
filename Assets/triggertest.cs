using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggertest : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    public void ToggleLight()
    {
        // Check for the key press you want to trigger the animation
        {
            // Trigger the animation by setting a trigger parameter in the Animator
            animator.SetTrigger("Trigger");
        }
    }
}

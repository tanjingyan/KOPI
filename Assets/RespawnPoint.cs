using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Function to respawn the GameObject
    public void Respawn()
    {
        // Reset the position and rotation to the original values
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // You can also reset other properties or variables here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Example: Pressing the "R" key to respawn the GameObject
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R works");
            Respawn();
        }
    }
}

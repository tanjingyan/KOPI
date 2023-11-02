using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target; // Reference to the target GameObject (e.g., the player)
    public float rotationSpeed = 2.0f;
    public float distance = 5.0f; // Adjust this distance as needed

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.position = target.position - (transform.forward * distance);
        
        //stopmovement
        transform.rotation = Quaternion.identity;
        
    }
}

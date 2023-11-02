using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticScript : MonoBehaviour
{
    public GameObject movingDoor;
    public GameObject movingDoor2;
    public float maximumOpening = 15f;
    public float maximumClosing = 0f;
    public float movementSpeed = 3f;
    bool playerIsHere;

    private Vector3 initialPosition;
    private Vector4 initialPosition2; // Store the initial position of the door

    void Start()
    {
        playerIsHere = false;
        initialPosition = movingDoor.transform.position; 
        initialPosition2 = movingDoor2.transform.position; // Store the initial position of the door
    }

    void Update()
    {
        Vector3 targetPosition = playerIsHere ? new Vector3(maximumOpening, initialPosition.y, initialPosition.z) : initialPosition;
        Vector4 targetPosition2 = playerIsHere ? new Vector4(-15f, initialPosition2.y, initialPosition2.z) : initialPosition2;

        if (movingDoor.transform.position.x != targetPosition.x)
        {
            float step = movementSpeed * Time.deltaTime;
            movingDoor.transform.position = Vector3.MoveTowards(movingDoor.transform.position, targetPosition, step);
        }

        if (movingDoor2.transform.position.x != targetPosition2.x)
        {
            float step = movementSpeed * Time.deltaTime;
            movingDoor2.transform.position = Vector3.MoveTowards(movingDoor2.transform.position, targetPosition2, step);
        }
    }
    // test

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = false;
        }
    }
}

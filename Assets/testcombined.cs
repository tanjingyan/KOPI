using UnityEngine;

public class testcombined : MonoBehaviour
{
    public GameObject lightSwitch; // Reference to the light switch GameObject
    public GameObject lightObject; // Reference to the light GameObject
    public Collider colliderZone; // Reference to the collider zone
    private Animator lightSwitchAnimator;
    public GameObject txtToDisplay; // Animator for the light switch

    private bool isLightOn = false; // Track the state of the light
    private bool playerInZone = false; // Check if the player is in the trigger
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        lightSwitchAnimator = lightSwitch.GetComponent<Animator>();
        audioSource = lightSwitch.GetComponent<AudioSource>();
        lightObject.SetActive(isLightOn); // Ensure the light is initially off
        txtToDisplay.SetActive(false);

    }

    private void Update()
    {
        if (playerInZone && Input.GetMouseButtonDown(0)) // If in zone and left mouse button is clicked
        {
            ToggleLightSwitch();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // If player enters zone
        {
            playerInZone = true;
            txtToDisplay.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // If player exits zone
        {
            playerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }

    private void ToggleLightSwitch()
    {
        isLightOn = !isLightOn; // Toggle the light state
        lightSwitchAnimator.SetBool("button", isLightOn); // Animate the light switch
        lightObject.SetActive(isLightOn); // Turn the light on/off
        audioSource.Play(); // Play the audio (assuming you have an AudioSource component)
    }
}
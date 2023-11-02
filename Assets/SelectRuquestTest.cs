using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using Normal.Realtime; 

public class SelectRuquestTest : MonoBehaviour
{
    private RealtimeTransform realtimeTransform;
    private XRSimpleInteractable xRSimpleInteractable;
    private AudioSource audioSource;

    void Start()
    {
        realtimeTransform = GetComponent<RealtimeTransform>();
        xRSimpleInteractable = GetComponent<XRSimpleInteractable>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (xRSimpleInteractable.isSelected)
        {
            realtimeTransform.RequestOwnership();

            if (audioSource != null)
            {
                // Play the audio when the GameObject is selected
                audioSource.Play();
            }
        }
    }
}
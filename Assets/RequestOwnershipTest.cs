using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using Normal.Realtime;

public class RequestOwnershipTest : MonoBehaviour
{
    [SerializeField] private RealtimeView realtimeView;
    [SerializeField] private RealtimeTransform realtimeTransform;
    [SerializeField] private XRGrabInteractable xRGrabInteractable;
    [SerializeField] private AudioSource audioSource; // Reference to the AudioSource component.

    private void OnEnable()
    {
        xRGrabInteractable.selectEntered.AddListener(RequestObjectOwnership);
    }

    private void RequestObjectOwnership(SelectEnterEventArgs args)
    {
        realtimeView.RequestOwnership();
        realtimeTransform.RequestOwnership();

        // Play the audio when the object is grabbed.
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnDisable()
    {
        xRGrabInteractable.selectEntered.RemoveListener(RequestObjectOwnership);
    }
}
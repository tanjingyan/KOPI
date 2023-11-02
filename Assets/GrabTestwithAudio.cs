using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using Normal.Realtime; 

public class GrabTestwithAudio : MonoBehaviour
{
    private RealtimeTransform realtimeTransform;
    private XRGrabInteractable xRGrabInteractable;

    /* erase if does not work*/
    [SerializeField]
    private AudioClip _audioClip = default;

    private AudioSource _audioSource;
    /* erase if does not work*/

    void Start()
    {
        realtimeTransform = GetComponent<RealtimeTransform>();
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (xRGrabInteractable.isSelected)
        {
            realtimeTransform.RequestOwnership();
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using Normal.Realtime; 

public class GrabRequest : MonoBehaviour
{
    private RealtimeTransform realtimeTransform;
    private XRGrabInteractable xRGrabInteractable;

    void Start()
    {
        realtimeTransform = GetComponent<RealtimeTransform>();
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        if (xRGrabInteractable.isSelected)
        {
            realtimeTransform.RequestOwnership();
        }
    }
}
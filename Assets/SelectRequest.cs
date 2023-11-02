using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using Normal.Realtime; 

public class SelectRequest : MonoBehaviour
{
    private RealtimeTransform realtimeTransform;
    private XRSimpleInteractable xRSimpleInteractable;

    void Start()
    {
        realtimeTransform = GetComponent<RealtimeTransform>();
        xRSimpleInteractable = GetComponent<XRSimpleInteractable>();
        
    }

    void Update()
    {
        if (xRSimpleInteractable.isSelected)
        {
            realtimeTransform.RequestOwnership();
            
        }
    }
}
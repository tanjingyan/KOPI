using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.Events;
using Normal.Realtime;


public class RequestOwnershipGrab : RealtimeComponent<GrabSync>
{
    [SerializeField] private RealtimeView realtimeView;
    [SerializeField] private RealtimeTransform realtimeTransform;
    [SerializeField] private XRGrabInteractable xRGrabInteractable;
    [SerializeField] private UnityEvent grabEvent;

    private void OnEnable() => xRGrabInteractable.selectEntered.AddListener(RequestObjectOwnership);

    private void RequestObjectOwnership(SelectEnterEventArgs args)
    {
        realtimeView.RequestOwnership();
        realtimeTransform.RequestOwnership();
        model.grabNumber++; //Trigger a network grab
        Debug.Log("Test");

    }

    private void OnDisable() => xRGrabInteractable.selectEntered.RemoveListener(RequestObjectOwnership);

    private void NetworkGrab(GrabSync model, int value)
    {
        grabEvent.Invoke();
    }

    protected override void OnRealtimeModelReplaced(GrabSync previousModel, GrabSync currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.grabNumberDidChange -= NetworkGrab;
        }

        if (currentModel != null)
        {
            //Register to number change
            currentModel.grabNumberDidChange += NetworkGrab;
        }
    }
}
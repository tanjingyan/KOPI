using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.Events;
using Normal.Realtime;

public class RequestOwnershipSelect : RealtimeComponent<GrabSync>
{
    [SerializeField] private RealtimeView realtimeView;
    [SerializeField] private RealtimeTransform realtimeTransform;
    [SerializeField] private XRSimpleInteractable xRSimpleInteractable;
    [SerializeField] private UnityEvent grabEvent;

    private void OnEnable() => xRSimpleInteractable.selectEntered.AddListener(RequestObjectOwnership);

    private void RequestObjectOwnership(SelectEnterEventArgs args)
    {
        realtimeView.RequestOwnership();
        realtimeTransform.RequestOwnership();
        model.grabNumber++; //Trigger a network grab
        Debug.Log("select");
    }

    private void OnDisable() => xRSimpleInteractable.selectEntered.RemoveListener(RequestObjectOwnership);

    private void NetworkGrab(GrabSync model, int value) {
        grabEvent.Invoke();
    }

    protected override void OnRealtimeModelReplaced(GrabSync previousModel, GrabSync currentModel) {
        if (previousModel != null) {
            // Unregister from events
            previousModel.grabNumberDidChange -= NetworkGrab;
        }
       
        if (currentModel != null) {
            //Register to number change
            currentModel.grabNumberDidChange += NetworkGrab;
        }
    }
}
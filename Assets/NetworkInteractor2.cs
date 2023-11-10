using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractor))]
public class NetworkInteractor2 : GUIDModel, ISelectionSet {
    public XRBaseInteractor interactor;
    public XRInteractionManager manager;

    private SelectionSet currentSet;

    private void Reset() {
        interactor = GetComponent<XRBaseInteractor>();
        Debug.Log("Reset hit");
    }

    private void OnEnable() {
        interactor.selectEntered.AddListener(SelectEnter);
       
        interactor.selectExited.AddListener(SelectExit);

        Debug.Log("Interactor on enable ");
        

        manager = FindObjectOfType<XRInteractionManager>();
        
    }

    //Item was selection
    private void SelectEnter(SelectEnterEventArgs args) {
        //Don't process if not local client
        if(!realtimeView.isOwnedLocallySelf) {
            Debug.Log("Interactor on SelectEnter");
            return;
        }

        //Have network process the selection
        SelectionSetManager.AddSet(new SelectionSet {
            interactorGUID = GUID,
            interactableGUID = args.interactableObject.transform.GetComponent<NetworkInteractable>().GUID
        });
        Debug.Log("processing selection");
    }

    private void Select(SelectionSet set) {
        //Don't double select on local client
        if(realtimeView.isOwnedLocallySelf) {
            Debug.Log("Interactor on Select selectionset");
            return;
        }

        manager.SelectEnter(interactor, GUIDManager.components[set.interactableGUID] as IXRSelectInteractable);
    }

    //Item was stopped being selected
    private void SelectExit(SelectExitEventArgs args) {
        //Don't process if not local client
        if(!realtimeView.isOwnedLocallySelf) {
            Debug.Log("Interactor on SelectExit");
            return;
        }

        //Tell other clients that we are now selecting nothing
        SelectionSetManager.AddSet(new SelectionSet 
        {
            interactorGUID = GUID,
            interactableGUID = "",
             
        });


        Debug.Log("Interactor on SelectExit2");
    }


    private void Deselect() {
        if(realtimeView.isOwnedLocallySelf) {
            Debug.Log("Interactor on Deselect");
            return;
        }

        manager.SelectExit(interactor, GUIDManager.components[currentSet.interactableGUID] as IXRSelectInteractable);
    }

    private void OnDisable() {
        interactor.selectEntered.RemoveListener(SelectEnter);
        interactor.selectExited.RemoveListener(SelectExit);
        Debug.Log("on disable");
    }

    //Receive network selection
    public void SetReceived(SelectionSet set) {
        UpdateSelection(set);
    }

    private void UpdateSelection(SelectionSet set) {
        string selectionGUID = set.interactableGUID;

        if(string.IsNullOrEmpty(selectionGUID) || GUIDManager.components.ContainsKey(selectionGUID)) {
            if(!string.IsNullOrEmpty(selectionGUID))
                Select(set);
                
            else
                Deselect();
                
        } else
            StartCoroutine(WaitForGUID(set));
            Debug.Log("start coroutine");

        if(realtimeView.isOwnedLocallySelf) {
            if(currentSet != null)
                SelectionSetManager.RemoveSet(currentSet);
                Debug.Log("own by local");

            currentSet = set;
        }
    }

    private IEnumerator WaitForGUID(SelectionSet set) {
        yield return new WaitUntil(() => GUIDManager.components.ContainsKey(set.interactableGUID));
        UpdateSelection(set);
    }
}
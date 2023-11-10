/*using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractor))]
public class NetworkInteractor : GUIDModel, ISelectionSet {
    public XRBaseInteractor interactor;
    public XRInteractionManager manager;

    private SelectionSet currentSet;

    private void Reset() {
        interactor = GetComponent<XRBaseInteractor>();
    }

    private void OnEnable() {
        interactor.selectEntered.AddListener(SelectEnter);
        interactor.selectExited.AddListener(SelectExit);

        manager = FindObjectOfType<XRInteractionManager>();
        Debug.Log("Test");
    }

    //Item was selection
    private void SelectEnter(SelectEnterEventArgs args) {
        //Don't process if not local client
        if(!realtimeView.isOwnedLocallySelf) {
            Debug.Log("Test");
            return;
        }

        //Have network process the selection
        SelectionSetManager.AddSet(new SelectionSet {
            interactorGUID = GUID,
            interactableGUID = args.interactableObject.transform.GetComponent<NetworkInteractable>().GUID
        });
    }

    private void Select(SelectionSet set) {
        //Don't double select on local client
        if(realtimeView.isOwnedLocallySelf) {
            
            return;
            Debug.Log("Test");
        }

        manager.SelectEnter(interactor, GUIDManager.components[set.interactableGUID] as IXRSelectInteractable);
    }

    //Item was stopped being selected
    private void SelectExit(SelectExitEventArgs args) {
        //Don't process if not local client
        if(!realtimeView.isOwnedLocallySelf) {
            return;
            Debug.Log("Test");
        }

        //Tell other clients that we are now selecting nothing
        SelectionSetManager.AddSet(new SelectionSet {
            interactorGUID = GUID,
            interactableGUID = ""
        });
    }

    private void Deselect() {
        if(realtimeView.isOwnedLocallySelf) {
            return;
            Debug.Log("Test");
        }

        manager.SelectExit(interactor, GUIDManager.components[currentSet.interactableGUID] as IXRSelectInteractable);
    }

    private void OnDisable() {
        interactor.selectEntered.RemoveListener(SelectEnter);
        interactor.selectExited.RemoveListener(SelectExit);
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

        if(realtimeView.isOwnedLocallySelf) {
            if(currentSet != null)
                SelectionSetManager.RemoveSet(currentSet);

            currentSet = set;
        }
    }

    private IEnumerator WaitForGUID(SelectionSet set) {
        yield return new WaitUntil(() => GUIDManager.components.ContainsKey(set.interactableGUID));
        UpdateSelection(set);
    }
}
*/
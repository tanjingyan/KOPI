using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRBaseInteractable))]
public class NetworkInteractable : GUIDModel {
	public XRBaseInteractable interactable;

	private void Reset() {
		interactable = GetComponent<XRBaseInteractable>();
	}
}
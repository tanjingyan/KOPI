using Normal.Realtime;
using Normal.Realtime.Serialization;

public class SelectionSetManager : RealtimeComponent<SelectionSetModel> {
	private static SelectionSetManager instance;

	private void Awake() {
		if(instance != null && instance != this)
			Destroy(this);
		else
			instance = this;

		realtime.didConnectToRoom += DidConnect;
	}

	private void DidConnect(Realtime real) {
		model.selectionSets.modelAdded += SetAdded;

		//Trigger all active Sets on join
		foreach(SelectionSet set in model.selectionSets) {
			if(!string.IsNullOrEmpty(set.interactorGUID)) {
				if(GUIDManager.components.ContainsKey(set.interactorGUID) && GUIDManager.components[set.interactorGUID].TryGetComponent(out ISelectionSet setter))
					setter.SetReceived(set);
			}
		}
	}

	private void SetAdded(RealtimeSet<SelectionSet> set, SelectionSet model, bool remote) {
		if(!string.IsNullOrEmpty(model.interactorGUID)) {
			if(GUIDManager.components[model.interactorGUID].TryGetComponent(out ISelectionSet setter)) {
				setter.SetReceived(model);
			}
		}
	}

	public static void AddSet(SelectionSet set) {
		instance.model.selectionSets.Add(set);
	}
		
	public static void RemoveSet(SelectionSet set) {
		instance.model.selectionSets.Remove(set);
	}
}

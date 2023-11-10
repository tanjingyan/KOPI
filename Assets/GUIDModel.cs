using Normal.Realtime;
using System;
using UnityEngine;

public class GUIDModel : RealtimeComponent<StringModel> {
	[HideInInspector] public string GUID => model.modelString;

	protected override void OnRealtimeModelReplaced(StringModel previousModel, StringModel currentModel) {
		if(currentModel.isFreshModel) {
			string guid = Guid.NewGuid().ToString();
			GUIDManager.components.Add(guid, this);
			currentModel.modelString = guid;
		} else {
			GUIDManager.components.Add(currentModel.modelString, this);
		}
	}

	private void OnDestroy() {
		GUIDManager.components.Remove(model.modelString);
	}
}
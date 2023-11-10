using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class StringModel {
	[RealtimeProperty(1, true, true)]
	private string _modelString;
}

public partial class StringModel : RealtimeModel {
	public string modelString {
		get {
			return _modelStringProperty.value;
		}
		set {
			if(_modelStringProperty.value == value) return;
			_modelStringProperty.value = value;
			InvalidateReliableLength();
			FireModelStringDidChange(value);
		}
	}

	public delegate void PropertyChangedHandler<in T>(StringModel model, T value);
	public event PropertyChangedHandler<string> modelStringDidChange;

	public enum PropertyID : uint {
		ModelString = 1,
	}

	#region Properties

	private ReliableProperty<string> _modelStringProperty;

	#endregion

	public StringModel() : base(null) {
		_modelStringProperty = new ReliableProperty<string>(1, _modelString);
	}

	protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
		_modelStringProperty.UnsubscribeCallback();
	}

	private void FireModelStringDidChange(string value) {
		try {
			modelStringDidChange?.Invoke(this, value);
		} catch(System.Exception exception) {
			UnityEngine.Debug.LogException(exception);
		}
	}

	protected override int WriteLength(StreamContext context) {
		var length = 0;
		length += _modelStringProperty.WriteLength(context);
		return length;
	}

	protected override void Write(WriteStream stream, StreamContext context) {
		var writes = false;
		writes |= _modelStringProperty.Write(stream, context);
		if(writes) InvalidateContextLength(context);
	}

	protected override void Read(ReadStream stream, StreamContext context) {
		var anyPropertiesChanged = false;
		while(stream.ReadNextPropertyID(out uint propertyID)) {
			var changed = false;
			switch(propertyID) {
				case (uint)PropertyID.ModelString: {
						changed = _modelStringProperty.Read(stream, context);
						if(changed) FireModelStringDidChange(modelString);
						break;
					}
				default: {
						stream.SkipProperty();
						break;
					}
			}
			anyPropertiesChanged |= changed;
		}
		if(anyPropertiesChanged) {
			UpdateBackingFields();
		}
	}

	private void UpdateBackingFields() {
		_modelString = modelString;
	}
}
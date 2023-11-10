using Normal.Realtime.Serialization;
using Normal.Realtime;

[RealtimeModel]
public partial class SelectionSetModel {
	[RealtimeProperty(1, true, true)]
	public RealtimeSet<SelectionSet> _selectionSets;
}
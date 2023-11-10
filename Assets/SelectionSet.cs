using Normal.Realtime;

[RealtimeModel]
public partial class SelectionSet {
	[RealtimeProperty(1, true)] private string _interactorGUID;
	[RealtimeProperty(2, true)] private string _interactableGUID;
}
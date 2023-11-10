using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerOwnership : MonoBehaviour
{
    public RealtimeView realtimeView;

    void Start()
    {
        if(realtimeView.isOwnedLocallySelf) {
            RealtimeView[] views = GetComponentsInChildren<RealtimeView>();
            foreach(RealtimeView view in views) {
                view.RequestOwnership();
            }
        }
    }
}
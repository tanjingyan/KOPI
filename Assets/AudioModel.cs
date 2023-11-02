using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class AudioModel {
    [RealtimeProperty(1, true)]
    private float _volume;


}
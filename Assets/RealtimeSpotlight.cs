using Normal.Realtime;
using UnityEngine;

public class RealtimeSpotlight : RealtimeComponent
{
    private Light _spotlight;

    public bool IsSpotlightEnabled
    {
        get { return _spotlight.enabled; }
        set
        {
            _spotlight.enabled = value;
        }
    }

    private void Awake()
    {
        _spotlight = GetComponent<Light>();
    }
}
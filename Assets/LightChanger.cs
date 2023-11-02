using System.Collections;
using System.Collections.Generic;
using Normal.Realtime.Serialization; 
using UnityEngine;
using Normal.Realtime;

public class LightChanger : RealtimeComponent<LightChangerModel>
{
    public Color[] colors;
    private Light spotlight;
    private int currLightidx = 0;

    [SerializeField]
    private AudioClip _audioClip = default;

    private AudioSource _audioSource;


    private void Awake()
    {
        spotlight = GetComponent<Light>();
        _audioSource = GetComponent<AudioSource>();
    }

    protected override void OnRealtimeModelReplaced(LightChangerModel previousModel, LightChangerModel currentModel)
    {
        //base.OnRealtimeModelReplaced(previousModel,currentModel);
        if (previousModel != null)
        {
            previousModel.colorDidChange -= ColorDidChange;
        }
        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.color = spotlight.color;
            }
            UpdateLightColor();

            currentModel.colorDidChange += ColorDidChange;
        }
    }

    private void ColorDidChange(LightChangerModel model, Color value)
    {
        UpdateLightColor();
    }

    void UpdateLightColor()
    {
        spotlight.color = model.color;
        _audioSource.PlayOneShot(_audioClip);
    }

    
    public void ChangeColor()
    {
        if (currLightidx < colors.Length - 1)
        {
            currLightidx += 1;
        }
        else
        {
            currLightidx = 0;
        }
        model.color = colors[currLightidx];
        
    }
}